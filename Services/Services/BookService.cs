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

        public void AddBook(BookViewModel model)
        {
            var book = new Book();
            if (!_repository.BookExists(model.Isbn!))
            {
                book.Title = model.Title;
                book.Description = model.Description;
                book.Image = model.Image;
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

                var genre = _dbContext.Genres.FirstOrDefault(x => x.Name == model.GenreName);
                if (genre == null)
                {
                    genre = new Genre()
                    {
                        Name = model.GenreName,
                        CreatedTime = DateTime.Now,
                        UpdatedTime = DateTime.Now,
                        CreatedBy = System.Environment.UserName,
                        UpdatedBy = System.Environment.UserName
                    };
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

                BookGenre bookGenre = new BookGenre()
                {
                    Book = book,
                    Genre = genre
                };
                _repository.AddBookGenre(bookGenre);
            }
            else
            {
                throw new InvalidDataException(Resources.Messages.Errors.BookExists);
            }
        }
    }
}
