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

        public void AddBookGenre(BookGenre bookGenre)
        {
            this.GetDbSet<BookGenre>().Add(bookGenre);
            UnitOfWork.SaveChanges();
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
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }

        public Book? GetBookByISBN(string isbn)
        {
            return this.GetDbSet<Book>().FirstOrDefault(x => x.Isbn == isbn);
        }

    }
}
