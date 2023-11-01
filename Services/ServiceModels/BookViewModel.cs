using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceModels
{
    public class BookViewModel
    {
        [Required(ErrorMessage = "Title is required.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Author is required.")]
        public string? AuthorName { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Image is required.")]
        public IFormFile? Image { get; set; }
        [Required(ErrorMessage = "Publish Date is required.")]
        public string? PublishDateStr { get; set; }
        [Required(ErrorMessage = "Publisher is required.")]
        public string? Publisher { get; set; }
        [Required(ErrorMessage = "ISBN is required.")]
        public string? Isbn { get; set; }
        [Required(ErrorMessage = "Language is required.")]
        public string? Language { get; set; }
        [Required(ErrorMessage = "Format is required.")]
        public string? Format { get; set; }
        [Required(ErrorMessage = "Pages is required.")]
        public string? PagesStr { get; set; }
        [Required(ErrorMessage = "Genre is required.")]
        public string? GenreName { get; set; }
    }
}
