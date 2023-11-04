using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class BookGenre
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

    }
}