using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class Rating
    {
        [Key]
        public int RatingId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int Value { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
        public ICollection<Review>? Reviews { get; set; }

    }
}
