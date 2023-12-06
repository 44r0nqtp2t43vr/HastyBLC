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
        public GenresController(IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IGenreService genreService,
                              IMapper? mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            this._genreService = genreService;
            this._logger = loggerFactory.CreateLogger<GenresController>();
        }

        /// <summary>
        /// Returns Home View.
        /// </summary>
        /// <returns> Home View </returns>

        [HttpGet]
        public IActionResult Genres(int page = 1)
        {
            const int pageSize = 12;
            var genresQuery = _genreService.GetGenres();

            var totalGenres = genresQuery.Count();
            var totalPages = (int)Math.Ceiling(totalGenres / (double)pageSize);

            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages;

            var currentPageGenres = genresQuery
                .OrderBy(genre => genre.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var viewModel = new GenresPageViewModel
            {
                Genres = currentPageGenres,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(viewModel);
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
