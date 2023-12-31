﻿using Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastyBLCAdmin.Models
{
    /// <summary>
    /// Book List View Model
    /// </summary>
    public class BookViewModel
    {
        public int BookId { get; set; }
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
        public string? AuthorName { get; set; }
        public List<string>? Genres { get; set; }
    }
}
