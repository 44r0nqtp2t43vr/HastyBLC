using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceModels
{
    public class BookSearchViewModel
    {
        public string? SearchText { get; set; }
        public List<Book>? Books { get; set; }
        public List<Genre>? Genres { get; set; }
        public List<bool>? IsGenreSelected { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalBooksCount {  get; set; }
    }

}
