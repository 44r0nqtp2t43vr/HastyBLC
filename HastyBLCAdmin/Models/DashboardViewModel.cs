using Data.Models;

namespace HastyBLCAdmin.Models
{
    public class DashboardViewModel
    {
        public List<Book>? topBooks { get; set; }
        public List<Book>? newBooks { get; set; }
    }
}
