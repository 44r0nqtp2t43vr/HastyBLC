using System.ComponentModel.DataAnnotations;

namespace HastyBLC.Models
{
    public class ReviewViewModel
    {
        public int BookId { get; set; }

        public string? BookTitle { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Stars is required.")]
        public int Stars { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        public string? Comment { get; set; }
    }
}