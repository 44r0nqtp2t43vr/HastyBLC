using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
        [ForeignKey("Review")]
        public int ReviewId { get; set; }
        public Review? Review { get; set; }
        public string? Description { get; set; }
    }
}
