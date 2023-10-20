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
        public void EditBook(string isbn, Book updatedBook)
        {
            var existingBook = this.GetDbSet<Book>().FirstOrDefault(x => x.Isbn == isbn);

            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title;
                existingBook.Description = updatedBook.Description;
                existingBook.Image = updatedBook.Image;
                existingBook.Publisher = updatedBook.Publisher;
                existingBook.Language = updatedBook.Language;
                existingBook.Format = updatedBook.Format;
                existingBook.Author = updatedBook.Author;
                existingBook.PublishDate = updatedBook.PublishDate;
                existingBook.Pages = updatedBook.Pages;
                existingBook.UpdatedTime = DateTime.Now;
                existingBook.UpdatedBy = System.Environment.UserName;

                UnitOfWork.SaveChanges();
            }
            else
            {
                throw new InvalidDataException("Book not found.");
            }
        }


        public Book? GetBookById(int bookId)
        {
            return this.GetDbSet<Book>().Find(bookId);
        }

        public Book? GetBookByISBN(string isbn)
        {
            return this.GetDbSet<Book>().FirstOrDefault(x => x.Isbn == isbn) ?? null;
        }

    }
}
