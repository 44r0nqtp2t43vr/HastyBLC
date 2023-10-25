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
        private readonly IBookService _bookService;
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

        public IActionResult Genres()
        {
            var genres = _context.Genres.ToList();
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
            var genreWithBooks = _context.Genres
                .Where(genre => genre.GenreId == genreId)
                .Include(genre => genre.BookGenres!)
                    .ThenInclude(bookGenre => bookGenre.Book)
                .ToList();

            return View(genreWithBooks[0]);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddGenre(GenreViewModel model)
        {
            try
            {
                /*_bookService.AddBook(model);*/
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
            return View();
        }
    }
}
