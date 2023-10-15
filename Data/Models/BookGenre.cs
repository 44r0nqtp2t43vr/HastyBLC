using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class BookGenre
    {
        [Key]
        public int BookGenreId { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

    }
}