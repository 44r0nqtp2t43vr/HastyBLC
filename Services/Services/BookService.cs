using Data;
using Data.Interfaces;
using Data.Models;
using Services.Interfaces;
using Services.Manager;
using Services.ServiceModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Hangfire.Annotations;
using System.Net;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;
        

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void AddBook(BookViewModel model, string imagePath)
        {
            var book = new Book();
            if (!_repository.BookExists(model.Isbn!))
            {
                book.Title = model.Title;
                book.Description = model.Description;
                book.Image = imagePath;
                book.Isbn = model.Isbn;
                book.Publisher = model.Publisher;
                book.Language = model.Language;
                book.Format = model.Format;

                var author = _repository.GetAuthors().FirstOrDefault(x => x.Name == model.AuthorName);
                if (author == null)
                {
                    book.Author = new Author()
                    {
                        Name = model.AuthorName,
                    };
                }
                else
                {
                    book.Author = author;
                }

                string genreNames = model.GenreNames!;
                char[] delimiter = { ',' };
                string[] genreStrings = genreNames.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
                List<Genre> genreList = new List<Genre>();

                foreach (var genreString in genreStrings)
                {
                    var genre = _repository.GetGenres().FirstOrDefault(x => x.Name!.ToLower() == genreString.Trim().ToLower());
                    if (genre == null)
                    {
                        genre = new Genre()
                        {
                            Name = genreString.Trim(),
                            CreatedTime = DateTime.Now,
                            UpdatedTime = DateTime.Now,
                            CreatedBy = System.Environment.UserName,
                            UpdatedBy = System.Environment.UserName
                        };
                    }
                    genreList.Add(genre);
                }
                

                DateTime dateTime;
                if (DateTime.TryParse(model.PublishDateStr, out dateTime))
                {
                    book.PublishDate = dateTime;
                }
                else
                {
                    throw new InvalidDataException("Invalid Data");
                }

                int number;
                if (int.TryParse(model.PagesStr, out number))
                {
                    book.Pages = number;
                }
                else
                {
                    throw new InvalidDataException("Invalid Data");
                }

                book.CreatedTime = DateTime.Now;
                book.UpdatedTime = DateTime.Now;
                book.CreatedBy = System.Environment.UserName;
                book.UpdatedBy = System.Environment.UserName;

                _repository.AddBook(book);

                foreach (var genre in genreList)
                {
                    BookGenre bookGenre = new BookGenre()
                    {
                        Book = book,
                        Genre = genre
                    };
                    _repository.AddBookGenre(bookGenre);
                }
                
            }
            else
            {
                throw new InvalidDataException(Resources.Messages.Errors.BookExists);
            }
        }

        public void DeleteBook(int bookId)
        {
            _repository.DeleteBook(bookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _repository.GetBooks().ToList();
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _repository.GetGenres().ToList();
        }

        public IEnumerable<Book> GetBooksWithReviews()
        {
            return _repository.GetBooks().Include(book => book.Reviews).ToList();
        }

        public IEnumerable<Book> GetBooksWithDetails()
        {
            return _repository.GetBooks().Include(b => b.Author).Include(b => b.BookGenres)!.ThenInclude(bg => bg.Genre).Include(b => b.Reviews)!.ThenInclude(r => r.Comments);
        }

        public IEnumerable<Book> GetBooksWithAuthorsAndGenres()
        {
            return _repository.GetBooks().Include(book => book.Author).Include(book => book.BookGenres)!.ThenInclude(bookGenre => bookGenre.Genre);
        }

        public IEnumerable<Book> GetTopBooks()
        {
            return _repository.GetBooks().Include(book => book.Reviews).OrderByDescending(b => b.Reviews!.Any() ? b.Reviews!.Average(r => r.Rating) : -1).ThenBy(b => b.Title);
        }
        public IEnumerable<Book> GetNewBooks()
        {
            return _repository.GetBooks().Include(book => book.Reviews).Where(b => b.CreatedTime >= DateTime.Now.AddDays(-14)).OrderByDescending(b => b.CreatedTime).ThenByDescending(book => book.BookId);
        }

        public void EditBook(BookViewModel model, string? imagePath)
        {
            var modeldup = model;
            var existingBook = _repository.GetBookById(model.BookId);

            if (existingBook == null)
            {
                throw new InvalidDataException("Book not found.");
            }
            else
            {
                existingBook.Isbn = model.Isbn;
                existingBook.Title = model.Title;
                existingBook.Description = model.Description;
                existingBook.Publisher = model.Publisher;
                existingBook.Language = model.Language;
                existingBook.Format = model.Format;

                if (imagePath != null && imagePath.Length > 0)
                {
                    existingBook.Image = imagePath;
                }

                existingBook.Author = _repository.GetAuthors().FirstOrDefault(x => x.Name == model.AuthorName);

                var author = _repository.GetAuthors().FirstOrDefault(x => x.Name == model.AuthorName!.Trim());
                if (author == null)
                {
                    author = new Author { Name = model.AuthorName!.Trim() };
                    _repository.AddAuthor(author);
                }
                existingBook.Author = author;


                DateTime publishDate;
                if (DateTime.TryParse(model.PublishDateStr, out publishDate))
                {
                    existingBook.PublishDate = publishDate;
                }
                else
                {
                    throw new InvalidDataException("Invalid Data");
                }

                int pages;
                if (int.TryParse(model.PagesStr, out pages))
                {
                    existingBook.Pages = pages;
                }
                else
                {
                    throw new InvalidDataException("Invalid Data");
                }

                existingBook.UpdatedTime = DateTime.Now;
                existingBook.UpdatedBy = System.Environment.UserName;

                _repository.EditBook(existingBook);

                var oldBookGenres = _repository.GetBookGenres().Include(bg => bg.Genre).Where(bg => bg.BookId == existingBook.BookId).ToList();
                foreach (var oldBookGenre in oldBookGenres)
                {
                    _repository.DeleteBookGenre(oldBookGenre);
                }

                string genreNames = model.GenreNames!;
                char[] delimiter = { ',' };
                string[] genreStrings = genreNames.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
                List<BookGenre> bookGenreList = new List<BookGenre>();

                foreach (var genreString in genreStrings)
                {
                    var genre = _repository.GetGenres().FirstOrDefault(x => x.Name!.ToLower() == genreString.Trim().ToLower());
                    if (genre == null)
                    {
                        genre = new Genre()
                        {
                            Name = genreString.Trim(),
                            CreatedTime = DateTime.Now,
                            UpdatedTime = DateTime.Now,
                            CreatedBy = System.Environment.UserName,
                            UpdatedBy = System.Environment.UserName
                        };
                    }
                    BookGenre bookGenre = new BookGenre()
                    {
                        Book = existingBook,
                        Genre = genre
                    };
                    _repository.AddBookGenre(bookGenre);

                }
            }
        }

        public void AddReview(ReviewViewModel model)
        {
            var review = new Review();
            review.BookId = model.BookId;
            review.Rating = model.Rating;
            review.Name = model.Name;
            review.UserEmail = model.UserEmail;
            review.Description = model.Description;
            review.CreatedTime = DateTime.Now;
            review.UpdatedTime = DateTime.Now;
            review.CreatedBy = System.Environment.UserName;
            review.UpdatedBy = System.Environment.UserName;
            _repository.AddReview(review);
        }

        public void AddComment(CommentViewModel model)
        {
            var comment = new Comment();
            comment.ReviewId = model.ReviewId;
            comment.Name = model.Name;
            comment.UserEmail = model.UserEmail;
            comment.Description = model.Description;
            comment.CreatedTime = DateTime.Now;
            comment.UpdatedTime = DateTime.Now;
            comment.CreatedBy = System.Environment.UserName;
            comment.UpdatedBy = System.Environment.UserName;
            _repository.AddComment(comment);
        }

        public IEnumerable<Book> SearchBooks(BookSearchViewModel model)
        {
            var query = _repository.SearchBooksByTitleOrAuthor(model.SearchText!);

            // Include Reviews for eager loading
            query = query.Include(book => book.Reviews);

            // Filter by selectedGenres
            if (model.IsGenreSelected != null && model.IsGenreSelected.Any(selected => selected))
            {
                var selectedGenreIds = model.IsGenreSelected
                    .Select((selected, index) => new { Selected = selected, Index = index })
                    .Where(item => item.Selected)
                    .Select(item => model.Genres![item.Index].GenreId);

                query = query.Where(book => book.BookGenres!.Any(bg => selectedGenreIds.Contains(bg.GenreId)));
            }

            return query.ToList();
        }

        public void EditReview(ReviewViewModel model)
        {
            var existingReview = _repository.GetReviewById(model.ReviewId);

            if (existingReview == null)
            {
                throw new InvalidDataException("Review not found.");
            }
            else
            {
                existingReview.Name = model.Name;
                existingReview.UserEmail = model.UserEmail;
                existingReview.Rating = model.Rating;
                existingReview.Description = model.Description;
                existingReview.UpdatedTime = DateTime.Now;
                existingReview.UpdatedBy = System.Environment.UserName;

                _repository.EditReview(existingReview);

            }
        }

        public void EditComment(CommentViewModel model)
        {
            var existingComment = _repository.GetCommentById(model.CommentId);

            if (existingComment == null)
            {
                throw new InvalidDataException("Comment not found.");
            }
            else
            {
                existingComment.Name = model.Name;
                existingComment.UserEmail = model.UserEmail;
                existingComment.Description = model.Description;
                existingComment.UpdatedTime = DateTime.Now;
                existingComment.UpdatedBy = System.Environment.UserName;

                _repository.EditComment(existingComment);

            }
        }

        public void DeleteReview(int reviewId)
        {
            _repository.DeleteReview(reviewId);
        }

        public void DeleteComment(int commentId)
        {
            _repository.DeleteComment(commentId);
        }
    }
}
