using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [ForeignKey("Rating")]
        public int RatingId { get; set; }
        public Rating? Rating { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}