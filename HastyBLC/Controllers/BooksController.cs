using HastyBLC.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Data;
using Data.Models;
using HastyBLC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Services.ServiceModels;
using Services.Interfaces;
using System;
using System.Linq;
using static Data.PathManager;
using Services.Services;
using static System.Reflection.Metadata.BlobBuilder;
using HastyBLC.Extensions;

namespace HastyBLC.Controllers
{
    public class BooksController : ControllerBase<BooksController>
    {
        private readonly HastyDBContext _context;
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;
        protected new ILogger _logger;
        public BooksController(HastyDBContext context,
                              IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IBookService bookService,
                              IGenreService genreService,
                              IMapper? mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {
            _context = context;
            this._bookService = bookService;
            this._genreService = genreService;
            this._logger = loggerFactory.CreateLogger<BooksController>();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Books()
        {
            // Retrieve data from the session
            var searchText = HttpContext.Session.GetString("SearchText");
            var books = HttpContext.Session.Get<List<Book>>("Books") ?? _bookService.GetBooksWithReviews().ToList();
            var genres = HttpContext.Session.Get<List<Genre>>("Genres") ?? _bookService.GetGenres().ToList();
            var isGenreSelected = HttpContext.Session.Get<List<bool>>("IsGenreSelected") ?? Enumerable.Repeat(false, genres.Count).ToList();
            var currentPage = HttpContext.Session.GetInt32("CurrentPage") ?? 0;
            var totalPages = HttpContext.Session.GetInt32("TotalPages") ?? 0;

            // Calculate average ratings for each book
            foreach (var book in books)
            {
                if (book.Reviews != null && book.Reviews.Count > 0)
                {
                    book.AverageRating = book.Reviews.Average(review => review.Rating);
                }
                else
                {
                    book.AverageRating = 0;
                }
            }
            var viewModel = new BookSearchViewModel
            {
                SearchText = searchText,
                Books = books,
                Genres = genres,
                IsGenreSelected = isGenreSelected,
                CurrentPage = currentPage,
                TotalPages = totalPages
            };

            return View(viewModel);
        }



        [HttpPost]
        [AllowAnonymous]
        public IActionResult SearchBooks(BookSearchViewModel model)
        {
            model.IsGenreSelected ??= new List<bool>();
            var genres = _bookService.GetGenres().ToList();
            var selectedGenres = genres.Where((genre, index) => model.IsGenreSelected![index]).ToList();
            var books = _bookService.SearchBooks(model).ToList();

            // Calculate average ratings for each book
            foreach (var book in books)
            {
                if (book.Reviews != null && book.Reviews.Count > 0)
                {
                    book.AverageRating = book.Reviews.Average(review => review.Rating);
                }
                else
                {
                    book.AverageRating = 0;
                }
            }
            
            // Store data in the session
            HttpContext.Session.SetString("SearchText", model.SearchText ?? "");
            HttpContext.Session.Set<List<Book>>("Books", books);
            HttpContext.Session.Set<List<Genre>>("Genres", genres);
            HttpContext.Session.Set<List<bool>>("IsGenreSelected", model.IsGenreSelected);
            HttpContext.Session.SetInt32("CurrentPage", model.CurrentPage);
            HttpContext.Session.SetInt32("TotalPages", model.TotalPages);

            return RedirectToAction("Books");
        }


        [HttpGet]
        [AllowAnonymous]
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
                }).ToList(),
                Percentages = new double[5]
            };

            if (book.Reviews != null && book.Reviews.Any())
            {
                var totalRatings = book.Reviews.Sum(review => review.Rating);
                var totalReviews = book.Reviews.Count;
                var ratingsCount = new int[5];

                foreach (var review in book.Reviews)
                {
                    int index = review.Rating - 1;
                    if (index >= 0 && index < ratingsCount.Length)
                    {
                        ratingsCount[index]++;
                    }
                }

                decimal averageRating = totalReviews > 0 ? (decimal)totalRatings / totalReviews : 0;
                bookViewModel.AverageRating = (double)averageRating;
                bookViewModel.AverageRatingRounded = Math.Round(averageRating, 1);
                bookViewModel.RoundedRating = (int)Math.Round(averageRating);

                for (int i = 0; i < ratingsCount.Length; i++)
                {
                    bookViewModel.Percentages[i] = totalReviews > 0 ? (double)ratingsCount[i] / totalReviews * 100 : 0;
                }
            }
            else
            {
                bookViewModel.AverageRating = 0;
                bookViewModel.AverageRatingRounded = 0;
                bookViewModel.RoundedRating = 0;
            }

            // Now that we've finished setting up our model, we can return it to the view
            return View(bookViewModel);


        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Review(Services.ServiceModels.ReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddReview(model);
                TempData["SuccessMessage"] = "Review submitted successfully!";
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
            return RedirectToAction("Books", "Books");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Comment(Services.ServiceModels.CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _bookService.AddComment(model);
                    TempData["SuccessMessage"] = "Comment submitted successfully!";
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
            }
            return RedirectToAction("Books", "Books");

        }
    }
}