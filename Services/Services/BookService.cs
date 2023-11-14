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

namespace Services.Services
{
    public class BookService : IBookService
    {
        private readonly HastyDBContext _dbContext;
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;
        

        public BookService(IBookRepository repository, IMapper mapper, HastyDBContext dbContext)
        {
            _mapper = mapper;
            _repository = repository;
            _dbContext = dbContext;
            
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

                var author = _dbContext.Authors.FirstOrDefault(x => x.Name == model.AuthorName);
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
                string[] genreStrings = genreNames.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                List<Genre> genreList = new List<Genre>();

                foreach (var genreString in genreStrings)
                {
                    var genre = _dbContext.Genres.FirstOrDefault(x => x.Name!.ToLower() == genreString.Trim().ToLower());
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
                    book.PublishDate = DateTime.MinValue;
                }

                int number;
                if (int.TryParse(model.PagesStr, out number))
                {
                    book.Pages = number;
                }
                else
                {
                    book.Pages = 0;
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

        public void EditBook(BookViewModel model, string imagePath)
        {
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

                if (imagePath.Length > 0)
                {
                    existingBook.Image = imagePath;
                }

                existingBook.Author = _dbContext.Authors?.FirstOrDefault(x => x.Name == model.AuthorName);

                var author = _dbContext.Authors?.FirstOrDefault(x => x.Name == model.AuthorName);
                if (author == null)
                {
                    author = new Author { Name = model.AuthorName };
                    _dbContext.Authors?.Add(author);
                }
                existingBook.Author = author;


                DateTime publishDate;
                if (DateTime.TryParse(model.PublishDateStr, out publishDate))
                {
                    existingBook.PublishDate = publishDate;
                }
                else
                {
                    existingBook.PublishDate = DateTime.MinValue;
                }

                int pages;
                if (int.TryParse(model.PagesStr, out pages))
                {
                    existingBook.Pages = pages;
                }
                else
                {
                    existingBook.Pages = 0;
                }

                existingBook.UpdatedTime = DateTime.Now;
                existingBook.UpdatedBy = System.Environment.UserName;

                _repository.EditBook(existingBook);

                var oldBookGenres = _dbContext.BookGenres.Where(bg => bg.BookId == existingBook.BookId).ToList();
                foreach (var oldBookGenre in oldBookGenres)
                {
                    _repository.DeleteBookGenre(oldBookGenre);
                }

                string genreNames = model.GenreNames!;
                char[] delimiter = { ',' };
                string[] genreStrings = genreNames.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                List<BookGenre> bookGenreList = new List<BookGenre>();

                foreach (var genreString in genreStrings)
                {
                    var genre = _dbContext.Genres.FirstOrDefault(x => x.Name!.ToLower() == genreString.Trim().ToLower());
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

        public IEnumerable<Book> SearchBooks(string searchCriteria)
        {
            return _repository.SearchBooks(searchCriteria).ToList();
        }
    }
}
