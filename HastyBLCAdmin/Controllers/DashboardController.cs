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

        public IActionResult Dashboard()
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
    }
}
