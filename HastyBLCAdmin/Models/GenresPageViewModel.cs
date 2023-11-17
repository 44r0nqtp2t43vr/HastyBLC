using Data.Models;
using System.Collections.Generic;

namespace HastyBLCAdmin.Models
{
    public class GenresPageViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
