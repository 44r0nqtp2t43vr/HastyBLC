using Data.Models;
using Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBookService
    {
        void AddBook(BookViewModel model, string imagePath);
        void DeleteBook(int bookId);
        IEnumerable<Book> GetBooks();
        IEnumerable<Genre> GetGenres();
        IEnumerable<Book> GetBooksWithReviews();
        void EditBook(BookViewModel model, string? imagePath);
        void AddReview(ReviewViewModel model);
        void AddComment(CommentViewModel model);
        IEnumerable<Book> SearchBooks(BookSearchViewModel model);
        void EditReview(ReviewViewModel model);
        void EditComment(CommentViewModel model);
        void DeleteReview(int reviewId);
        void DeleteComment(int commentId);
    }
}
