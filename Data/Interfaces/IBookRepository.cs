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
        Book? GetBookByISBN(string isbn);
    }
}
