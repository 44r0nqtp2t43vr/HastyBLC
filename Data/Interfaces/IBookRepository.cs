using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Book> GetBooks();
        IQueryable<Genre> GetGenres();
        IQueryable<Author> GetAuthors();
        IQueryable<BookGenre> GetBookGenres();
        bool BookExists(string isbn);
        void AddBook(Book book);
        void AddGenre(Genre genre);
        void AddAuthor(Author author);
        void AddBookGenre(BookGenre bookGenre);
        void DeleteBookGenre(BookGenre bookGenre);
        void EditBook(Book updatedBook);
        void DeleteBook(int bookId);
        Book? GetBookById(int bookId);
        void AddReview(Review review);
        void AddComment(Comment comment);
        IQueryable<Book> SearchBooksByTitleOrAuthor(string searchCriteria);
        void EditReview(Review updatedReview);
        void EditComment(Comment updatedComment);
        void DeleteReview(int reviewId);
        void DeleteComment(int commentId);
        Review? GetReviewById(int reviewId);
        Comment? GetCommentById(int commentId);
    }
}
