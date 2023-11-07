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
using Services.Services;

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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ViewBook(int id, bool ignoreReview = false)
        {
            var book = _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookGenres)!
                .ThenInclude(bg => bg.Genre)
                .Include(b => b.Reviews)! // Include the reviews for the book
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

            if (ignoreReview)
            {
                // Adjust the URL if it came from a review page
                var previousUrl = Request.Headers["Referer"].ToString();
                var previousPage = previousUrl.Substring(previousUrl.LastIndexOf("Review"));
                var updatedUrl = previousUrl.Replace(previousPage, "");

                return Redirect(updatedUrl);
            }

            return View(bookViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
        public IActionResult Review(Services.ServiceModels.ReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddReview(model);
                TempData["SuccessMessage"] = "Review submitted successfully!";
                return RedirectToAction("ViewBook", new { id = model.BookId });

            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Comment(Services.ServiceModels.CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _bookService.AddComment(model);
                    TempData["SuccessMessage"] = "Comment submitted successfully!";
                    return RedirectToAction("ViewBook", new { id = model.BookId });
                }
                catch (InvalidDataException ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                }
                catch (Exception)
                {
                    TempData["ErrorMessage"] = Resources.Messages.Errors.ServerError;
                }
                return RedirectToAction("Genres", "Genres");
            }
            return View(model);
            
        }
    }
}