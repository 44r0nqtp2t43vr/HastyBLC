using Data.Models;
using System.Collections.Generic;

namespace HastyBLCAdmin.Models
{
    public class BooksPageViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
