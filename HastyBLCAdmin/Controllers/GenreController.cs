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
    public class GenresController : ControllerBase<GenresController>
    {
        private readonly HastyDBContext _context;
        private readonly IGenreService _genreService;
        protected new ILogger _logger;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="mapper"></param>
        public GenresController(HastyDBContext context,
                              IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IGenreService genreService,
                              IMapper? mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _context = context;
            this._genreService = genreService;
            this._logger = loggerFactory.CreateLogger<GenresController>();
        }

        /// <summary>
        /// Returns Home View.
        /// </summary>
        /// <returns> Home View </returns>

        public IActionResult Genres()
        {
            var genres = _genreService.GetGenres();
            return View(genres);
        }

        public IActionResult BackToGenres()
        {
            return RedirectToAction("Genres", "Genres");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ViewGenre(int genreId)
        {
            var genre = _genreService.GetGenre(genreId);
            return View(genre);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddGenre(GenreViewModel model)
        {
            try
            {
                _genreService.AddGenre(model);
                return RedirectToAction("Genres", "Genres");
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

        [HttpPost]
        [AllowAnonymous]
        public IActionResult EditGenre(GenreViewModel model)
        {
            try
            {
                _genreService.EditGenre(model);
                return RedirectToAction("Genres", "Genres");
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

        [HttpPost]
        [AllowAnonymous]
        public IActionResult DeleteGenre(int genreId)
        {
            try
            {
                _genreService.DeleteGenre(genreId);
                return RedirectToAction("Genres", "Genres");
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
        public IActionResult ViewBook(int id)
        {
            // Fetch the book using the provided ID
            var book = _context.Books
                               .Include(b => b.Author)
                               .Include(b => b.BookGenres)
                               .ThenInclude(bg => bg.Genre)
                               .FirstOrDefault(b => b.BookId == id);

            if (book == null)
            {
                // Handle the case where the book isn't found
                return NotFound();
            }

            // Create a new instance of the ViewModel and map the properties
            var viewModel = new HastyBLCAdmin.Models.BookViewModel
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
                AuthorName = book.Author?.Name, // Assuming Author has a Name property
                Genres = book.BookGenres.Select(bg => bg.Genre.Name).ToList() // Assuming Genre has a Name property
            };

            // Pass the ViewModel to the View
            return View("~/Views/Books/ViewBook.cshtml", viewModel);
        }



    }
}
