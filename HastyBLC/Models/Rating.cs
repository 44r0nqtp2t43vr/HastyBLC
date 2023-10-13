using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastyBLC.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public decimal Value { get; set; }
        public Review? Review { get; set; }

    }
}
