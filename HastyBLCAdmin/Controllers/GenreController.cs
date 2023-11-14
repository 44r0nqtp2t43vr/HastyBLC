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
    [Authorize(Roles = "Admin")]
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
        public IActionResult ViewGenre(int genreId)
        {
            var genre = _genreService.GetGenre(genreId);
            return View(genre);
        }

        [HttpPost]
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

    }
}
