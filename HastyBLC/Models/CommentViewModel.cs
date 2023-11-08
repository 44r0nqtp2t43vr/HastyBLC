﻿namespace HastyBLC.Models
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public string? UserEmail { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
