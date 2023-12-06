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

namespace HastyBLC.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class DashboardController : ControllerBase<DashboardController>
    {
        private readonly IBookService _bookService;
        protected new ILogger _logger;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="mapper"></param>
        public DashboardController(IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IBookService bookService,
                              IMapper? mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            this._bookService = bookService;
            this._logger = loggerFactory.CreateLogger<DashboardController>();
        }

        /// <summary>
        /// Returns Home View.
        /// </summary>
        /// <returns> Home View </returns>

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Dashboard()
        {
            var books = _bookService.GetBooksWithReviews();
            return View(books);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult NewBooks(int page = 1)
        {
            int pageSize = 10;
            var books = _bookService.GetBooks();

            var fourteenDaysAgo = DateTime.Now.AddDays(-14);
            var orderedBooks = books?
                .Where(book => book.CreatedTime >= fourteenDaysAgo)
                .OrderByDescending(book => book.CreatedTime)
                .ThenByDescending(book => book.BookId)
                .ToList(); 

            int totalItems = orderedBooks?.Count() ?? 0;
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            if (totalPages == 0)
                totalPages = 1;

            page = Math.Max(1, Math.Min(page, totalPages));

            var currentPageBooks = orderedBooks
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;

            return View(currentPageBooks);
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult TopBooks(int page = 1)
        {
            var pageSize = 10;

            var books = _bookService.GetBooksWithReviews();

            // Calculate average ratings for each book
            foreach (var book in books)
            {
                if (book.Reviews != null && book.Reviews.Count > 0)
                {
                    book.AverageRating = book.Reviews.Average(review => review.Rating);
                }
                else
                {
                    book.AverageRating = 0;
                }
            }
            var orderedBooks = books.OrderByDescending(book => book.AverageRating).ThenBy(b => b.Title).ToList();

            int totalItems = orderedBooks.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages;

            var currentPageBooks = orderedBooks
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;

            return View(currentPageBooks);
        }
    }
}
