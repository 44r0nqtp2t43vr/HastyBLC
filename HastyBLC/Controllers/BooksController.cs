using HastyBLC.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using Services.Services;

namespace HastyBLC.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class BooksController : ControllerBase<BooksController>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="mapper"></param>
        private readonly IBookService _bookService;
        public BooksController(IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IBookService bookService,
                              IMapper? mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Returns Home View.
        /// </summary>
        /// <returns> Home View </returns>
        public IActionResult Books()
        {
            var books = _bookService.GetBooks();
            return View(books);
        }

        [HttpPost]
        public IActionResult DeleteBook(int bookId)
        {
            _bookService.DeleteBook(bookId);   
            return RedirectToAction("Index");  
        }
    }
}