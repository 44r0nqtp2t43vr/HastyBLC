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
        public Book? GetBookByISBN(string isbn)
        {
            return this.GetDbSet<Book>().FirstOrDefault(x => x.Isbn == isbn);
        }

    }
}
