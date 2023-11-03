using HastyBLCAdmin.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Data;
using Data.Models;
using HastyBLCAdmin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Services.ServiceModels;
using Services.Interfaces;

namespace HastyBLCAdmin.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class DashboardController : ControllerBase<DashboardController>
    {
        private readonly HastyDBContext _context;
        private readonly IBookService _bookService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="mapper"></param>
        public DashboardController(HastyDBContext context,
                              IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IBookService bookService,
                              IMapper? mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _context = context;
            this._bookService = bookService;
        }

        /// <summary>
        /// Returns Home View.
        /// </summary>
        /// <returns> Home View </returns>

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Dashboard()
        {
            var books = _bookService.GetBooks();
            return View(books);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult NewBooks(int page = 1)
        {
            int pageSize = 10; 
            var books = _bookService.GetBooks(); 

            var orderedBooks = books.OrderByDescending(book => book.CreatedTime);

            int totalItems = orderedBooks.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            
            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages;

            
            var currentPageBooks = orderedBooks.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;

            return View(currentPageBooks);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult TopBooks(int page=1)
        {
            var books = _bookService.GetBooks();
            int pageSize = 10; 

            var orderedBooks = books.OrderByDescending(book => book.BookId);

            int totalItems = orderedBooks.Count();
            int totalPages = (int)Math.Ceiling(totalItems/(double)pageSize);

            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages;

            var currentPageBooks = orderedBooks.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;

            return View(currentPageBooks);
        }
    }
}
