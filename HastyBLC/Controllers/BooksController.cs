using HastyBLC.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Data;
using Data.Models;
using HastyBLC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Services.ServiceModels;
using Services.Interfaces;
using System;
using System.Linq;
using static Data.PathManager;

namespace HastyBLC.Controllers
{
    public class BooksController : ControllerBase<BooksController>
    {
        private readonly HastyDBContext _context;
        private readonly IBookService _bookService;
        protected new ILogger _logger;
        public BooksController(HastyDBContext context,
                              IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IBookService bookService,
                              IMapper? mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _context = context;
            this._bookService = bookService;
            this._logger = loggerFactory.CreateLogger<BooksController>();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Books()
        {
            var books = _bookService.GetBooks();
            return View(books);
        }

        public IActionResult ViewBook(int id)
        {
            var book = _context.Books
        .Include(b => b.Author)
        .Include(b => b.BookGenres)
        .ThenInclude(bg => bg.Genre)
        .Include(b => b.Reviews) // Include the reviews for the book
        .ThenInclude(r => r.Comments) // Include comments for each review
        .FirstOrDefault(b => b.BookId == id);

            if (book == null)
            {
                TempData["ErrorMessage"] = "Book not found.";
                return RedirectToAction("Books");
            }

            var genreNames = book.BookGenres?.Select(bg => bg.Genre?.Name);
            var concatGenre = string.Join(", ", genreNames!);

            var bookViewModel = new Models.BookViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                Description = book.Description,
                Image = book.Image,
                PublishDate = book.PublishDate,
                Publisher = book.Publisher,
                Isbn = book.Isbn,
                Language = book.Language,
                Format = book.Format,
                Pages = book.Pages,
                AuthorName = book.Author!.Name,
                Genres = book.BookGenres!.Select(bookGenre => bookGenre.Genre!.Name).ToList()!,
                Reviews = book.Reviews?.Select(review => new Models.ReviewViewModel
                {
                    ReviewId = review.ReviewId,
                    Rating = review.Rating,
                    Description = review.Description,
                    Name = review.Name,
                    UserEmail = review.UserEmail,
                    CreatedBy = review.CreatedBy,
                    CreatedTime = review.CreatedTime,
                    UpdatedBy = review.UpdatedBy,
                    UpdatedTime = review.UpdatedTime,
                    Comments = review.Comments?.Select(comment => new Models.CommentViewModel
                    {
                        CommentId = comment.CommentId,
                        Description = comment.Description,
                        Name = comment.Name,
                        UserEmail = comment.UserEmail,
                        CreatedBy = comment.CreatedBy,
                        CreatedTime = comment.CreatedTime,
                        UpdatedBy = comment.UpdatedBy,
                        UpdatedTime = comment.UpdatedTime,
                    }).ToList()
                }).ToList()
            };

            return View(bookViewModel);
        }

        [HttpGet]
        public IActionResult Review(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == id);

            if (book == null)
            {
                TempData["ErrorMessage"] = "Book not found.";
                return RedirectToAction("Books");
            }

            var reviewViewModel = new Services.ServiceModels.ReviewViewModel
            {
                BookId = id,
                BookTitle = book.Title
            };

            return View(reviewViewModel);
        }

        [HttpPost]
        public IActionResult Review(Services.ServiceModels.ReviewViewModel reviewViewModel)
        {
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Review submitted successfully!";
                return RedirectToAction("ViewBook", new { id = reviewViewModel.BookId });
            }

            return View(reviewViewModel);
        }
    }
}