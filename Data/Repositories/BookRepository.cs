using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IQueryable<Book> GetBooks()
        {
            return this.GetDbSet<Book>();
        }

        public bool BookExists(string isbn)
        {
            return this.GetDbSet<Book>().Any(x => x.Isbn == isbn);
        }

        public void AddBook(Book book)
        {
            this.GetDbSet<Book>().Add(book);
            UnitOfWork.SaveChanges();
        }
        public void DeleteBookGenre(BookGenre bookGenre)
        {
            this.GetDbSet<BookGenre>().Remove(bookGenre);
            UnitOfWork.SaveChanges();
        }

        public void AddBookGenre(BookGenre bookGenre)
        {
            this.GetDbSet<BookGenre>().Add(bookGenre);
            UnitOfWork.SaveChanges();
        }
        public void EditBook(Book updatedBook)
        {
            try
            {
                var book = this.GetDbSet<Book>().Find(updatedBook.BookId);
                if (book != null)
                {
                    this.GetDbSet<Book>().Update(book);
                    UnitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception here to see if any error is occurring
                Console.WriteLine(ex.Message);
            }

        }
        public void DeleteBook(int bookId)
        {
            try
            {
                var book = this.GetDbSet<Book>().Find(bookId);
                if (book != null)
                {
                    this.GetDbSet<Book>().Remove(book);
                    UnitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception here to see if any error is occurring
                Console.WriteLine(ex.Message);
            }

        }

        public Book? GetBookById(int bookId)
        {
            return this.GetDbSet<Book>().FirstOrDefault(x => x.BookId == bookId);
        }

        public void AddReview(Review review)
        {
            this.GetDbSet<Review>().Add(review);
            UnitOfWork.SaveChanges();
        }

        public void AddComment(Comment comment)
        {
            this.GetDbSet<Comment>().Add(comment);
            UnitOfWork.SaveChanges();
        }

        public void DeleteReview(int reviewId)
        {
            try
            {
                var review = this.GetDbSet<Review>().Find(reviewId);
                if (review != null)
                {
                    this.GetDbSet<Review>().Remove(review);
                    UnitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception here to see if any error is occurring
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
