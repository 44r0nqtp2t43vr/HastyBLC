using System.ComponentModel.DataAnnotations;

namespace HastyBLC.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string? Name { get; set; }
        public ICollection<BookGenre>? BookGenres { get; set; }

    }
}
