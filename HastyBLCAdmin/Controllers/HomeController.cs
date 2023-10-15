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

namespace HastyBLCAdmin.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : ControllerBase<HomeController>
    {
        private readonly HastyDBContext _context;
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
                              IMapper? mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _context = context;
        }

        /// <summary>
        /// Returns Home View.
        /// </summary>
        /// <returns> Home View </returns>
        public IActionResult Index()
        {
            // Query all books from the database
            var books = _context.Books
                .Include(book => book.Author)
                .Include(book => book.BookGenres)!
                    .ThenInclude(bookGenre => bookGenre.Genre)
                .Select(book => new BookViewModel
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