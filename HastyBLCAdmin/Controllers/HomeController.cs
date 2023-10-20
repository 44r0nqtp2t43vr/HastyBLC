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
using System;
using System.Linq;

namespace HastyBLCAdmin.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : ControllerBase<HomeController>
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
        public HomeController(HastyDBContext context,
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
        public IActionResult Index()
        {
            var books = _context.Books
                .Include(book => book.Author)
                .Include(book => book.BookGenres)!
                    .ThenInclude(bookGenre => bookGenre.Genre)
                .Select(book => new Models.BookViewModel
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
                    CreatedBy = book.CreatedBy,
                    CreatedTime = book.CreatedTime,
                    UpdatedBy = book.UpdatedBy,
                    UpdatedTime = book.UpdatedTime,
                    AuthorName = book.Author!.Name,
                    Genres = book.BookGenres!.Select(bookGenre => bookGenre.Genre!.Name).ToList()!,
                })
                .ToList();
            var viewModel = new BookListViewModel { Books = books };

            return View(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddBook(Services.ServiceModels.BookViewModel model)
        {
            try
            {
                _bookService.AddBook(model);
                return RedirectToAction("Index", "Home");
            }
            catch (InvalidDataException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = Resources.Messages.Errors.ServerError;
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult DeleteBook(int bookId) 
        {
            try
            {
                _bookService.DeleteBook(bookId); 
                TempData["SuccessMessage"] = "Book deleted successfully.";
            }
            catch (Exception ex) 
            {
                TempData["ErrorMessage"] = $"Error deleting book: {ex.Message}";
            }

            return RedirectToAction("Index"); 
	}

        [HttpGet]
        [AllowAnonymous]
        public IActionResult EditBook(string isbn)
        {
            var existingBook = _context.Books.Include(book=> book.Author).Include(book => book.BookGenres)!
                    .ThenInclude(bookGenre => bookGenre.Genre)
                .FirstOrDefault(book => book.Isbn == isbn);

            if (existingBook == null)
            {
                TempData["ErrorMessage"] = "Book not found.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var genreNames = existingBook.BookGenres?.Select(bg => bg.Genre?.Name);
                var concatGenre = string.Join(", ", genreNames!);

                var model = new Services.ServiceModels.BookViewModel
                {
                    Title = existingBook.Title,
                    Description = existingBook.Description,
                    Image = existingBook.Image,
                    Publisher = existingBook.Publisher,
                    Language = existingBook.Language,
                    Format = existingBook.Format,
                    GenreName = concatGenre?.ToString(),
                    AuthorName = existingBook.Author?.Name,
                    PublishDateStr = existingBook.PublishDate.ToString("yyyy-MM-dd"),
                    PagesStr = existingBook.Pages.ToString(),
                    Isbn = existingBook.Isbn,
                };
                return View(model);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult EditBook(string isbn, Services.ServiceModels.BookViewModel model)
        {
            try
            {
                _bookService.EditBook(isbn,model);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = Resources.Messages.Errors.ServerError;
                return View(model);
            }
        }
    }
}
