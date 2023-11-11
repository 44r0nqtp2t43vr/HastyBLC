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
using static Data.PathManager;
using Services.Services;

namespace HastyBLCAdmin.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class BooksController : ControllerBase<BooksController>
    {
        private readonly HastyDBContext _context;
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

        /// <summary>
        /// Returns Home View.
        /// </summary>
        /// <returns> Home View </returns>
        

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
                    // Set the imagePath variable to be used in your service or repository method
                    _bookService.AddBook(model, "");
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
        public IActionResult EditBook(int bookId)
        {
            var existingBook = _context.Books.Include(book=> book.Author).Include(book => book.BookGenres)!
                    .ThenInclude(bookGenre => bookGenre.Genre)
                .FirstOrDefault(book => book.BookId == bookId);

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
                    BookId = existingBook.BookId,
                    Title = existingBook.Title,
                    Description = existingBook.Description,
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
        public IActionResult EditBook(Services.ServiceModels.BookViewModel model)
        {
            try
            {
                string? filePath;
                if (model.Image != null && model.Image.Length > 0)
                {
                    string uploadsDirectory = "uploads/images"; // Specify the directory to save the images
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    filePath = Path.Combine(uploadsDirectory, uniqueFileName).Replace('\\', '/'); // Replacing backslashes with forward slashes

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
                    _bookService.EditBook(model, filePath);
                    return RedirectToAction("Books", "Books");
                }
                else
                {
                    _bookService.EditBook(model, "");
                    return RedirectToAction("Books", "Books");
                }
                
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Books(int page = 1)
        {
            const int pageSize = 10;
            var booksQuery = _context.Books.AsQueryable();

            var totalBooks = booksQuery.Count();
            var totalPages = (int)Math.Ceiling(totalBooks / (double)pageSize);

            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages;

            var currentPageBooks = booksQuery
                .OrderByDescending(book => book.CreatedTime)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var viewModel = new BooksPageViewModel
            {
                Books = currentPageBooks,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult EditComment(Services.ServiceModels.CommentViewModel model)
        {
            try
            {
                _bookService.EditComment(model);
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
            return RedirectToAction("Books", "Books");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult DeleteReview(int reviewId)
        {
            try
            {
                _bookService.DeleteReview(reviewId);
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
            return RedirectToAction("Books", "Books");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult DeleteComment(int commentId)
        {
            try
            {
                _bookService.DeleteComment(commentId);
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
            return RedirectToAction("Books", "Books");
        }

    }
}
