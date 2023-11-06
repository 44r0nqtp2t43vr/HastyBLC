using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceModels
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

        [Required(ErrorMessage = "Review is required.")]
        public string? Description { get; set; }
    }
}
