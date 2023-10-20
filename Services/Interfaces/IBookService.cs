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
        void AddBook(BookViewModel model);
        void EditBook(string isbn, BookViewModel model);
    }
}
