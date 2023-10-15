using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public partial class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
        public ICollection<BookGenre>? BookGenres { get; set; }

    }
}