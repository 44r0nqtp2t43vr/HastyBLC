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
            return View();
        }
    }
}
