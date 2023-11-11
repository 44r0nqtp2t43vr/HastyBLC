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
        bool BookExists(string isbn);
        void AddBook(Book book);
        void AddBookGenre(BookGenre bookGenre);
        void DeleteBookGenre(BookGenre bookGenre);
        void EditBook(Book updatedBook);
        void DeleteBook(int bookId);
        Book? GetBookById(int bookId);
        void AddReview(Review review);
        void AddComment(Comment comment);
        void EditComment(Comment updatedComment);
        void DeleteReview(int reviewId);
        void DeleteComment(int commentId);
        Comment? GetCommentById(int commentId);
    }
}
