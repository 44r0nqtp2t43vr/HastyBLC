using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceModels
{
    public class CommentViewModel
    {
        public int BookId { get; set; }
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        public string? Description { get; set; }
    }
}
