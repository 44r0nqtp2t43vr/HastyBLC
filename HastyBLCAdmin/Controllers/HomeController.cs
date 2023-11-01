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
    public class BooksController : ControllerBase<BooksController>
    {
        private readonly HastyDBContext _context;
        private readonly IBookService _bookService;
        private readonly string ImageUploadsDirectory = "uploads/";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="mapper"></param>
        public BooksController(HastyDBContext context,
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
        public IActionResult Books()
        {
            var books = _bookService.GetBooks();
            return View(books);
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
                if (model.Image != null && model.Image.Length > 0)
                {
                    string uploadsDirectory = "uploads/images"; // Specify the directory to save the images
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsDirectory, uniqueFileName).Replace('\\', '/'); // Replacing backslashes with forward slashes

                    string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);

                    // Check if the directory exists, if not, create it
                    if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
                    }

                    // Save the file to the specified path
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        model.Image.CopyTo(fileStream);
                    }

                    // Set the imagePath variable to be used in your service or repository method
                    _bookService.AddBook(model, filePath);
                    return RedirectToAction("Books", "Books");
                } else
                {
                    throw new Exception();
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
                return RedirectToAction("Books", "Books");

            }
            catch (Exception ex) 
            {
                TempData["ErrorMessage"] = $"Error deleting book: {ex.Message}";
            }

            return RedirectToAction("ViewBook", "Books");
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
                return RedirectToAction("Books", "Books");
            }
            else
            {
                var genreNames = existingBook.BookGenres?.Select(bg => bg.Genre?.Name);
                var concatGenre = string.Join(", ", genreNames!);

                var model = new Services.ServiceModels.BookViewModel
                {
                    Title = existingBook.Title,
                    Description = existingBook.Description,
                    /*Image = existingBook.Image,*/
                    Publisher = existingBook.Publisher,
                    Language = existingBook.Language,
                    Format = existingBook.Format,
                    GenreNames = concatGenre?.ToString(),
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
                return RedirectToAction("Books", "Books");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = Resources.Messages.Errors.ServerError;
                return View(model);
            }
        }
        public IActionResult ViewBook(int id)
        {
            var book = _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookGenres)!
                .ThenInclude(bg => bg.Genre)
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
            };

            return View(bookViewModel);
        }


    }
}
