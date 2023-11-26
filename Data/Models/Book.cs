using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class Book
    {
        [Key]
        public int BookId { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime PublishDate { get; set; }
        public string? Publisher { get; set; }
        public string? Isbn { get; set; }
        public string? Language { get; set; }
        public string? Format { get; set; }
        public int Pages { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
        public ICollection<BookGenre>? BookGenres { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public double CalculateAverageRating
        {
            get
            {
                if (Reviews == null || Reviews.Count == 0)
                {
                    return 0; // or any default value for no reviews
                }

                return Reviews.Average(review => review.Rating);
            }
        }
        [NotMapped]
        public double AverageRating { get; set; }

    }
}