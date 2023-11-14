﻿using HastyBLC.Mvc;
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
        private readonly IGenreService _genreService;
        protected new ILogger _logger;
        public BooksController(HastyDBContext context,
                              IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IBookService bookService,
                              IGenreService genreService,
                              IMapper? mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _context = context;
            this._bookService = bookService;
            this._genreService = genreService;
            this._logger = loggerFactory.CreateLogger<BooksController>();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Books()
        {
            var books = _bookService.GetBooks();
            ViewBag.Genres = _genreService.GetGenres();
            return View(books);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ViewBook(int id)
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

            return View(bookViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Review(Services.ServiceModels.ReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddReview(model);
                TempData["SuccessMessage"] = "Review submitted successfully!";
                // Get the URL of the referring page
                string referrerUrl = ControllerContext.HttpContext.Request.Headers["Referer"].ToString();

                if (!string.IsNullOrEmpty(referrerUrl))
                {
                    // Redirect back to the referring page
                    return Redirect(referrerUrl);
                }
                else
                {
                    // If no referrer is available, you can redirect to a default action or URL
                    return RedirectToAction("Books", "Books");
                }

            }
            return RedirectToAction("Books", "Books");
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
                    // Get the URL of the referring page
                    string referrerUrl = ControllerContext.HttpContext.Request.Headers["Referer"].ToString();

                    if (!string.IsNullOrEmpty(referrerUrl))
                    {
                        // Redirect back to the referring page
                        return Redirect(referrerUrl);
                    }
                    else
                    {
                        // If no referrer is available, you can redirect to a default action or URL
                        return RedirectToAction("Books", "Books");
                    }
                }
                catch (InvalidDataException ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                }
                catch (Exception)
                {
                    TempData["ErrorMessage"] = Resources.Messages.Errors.ServerError;
                }
            }
            return RedirectToAction("Books", "Books");

        }
    }
}