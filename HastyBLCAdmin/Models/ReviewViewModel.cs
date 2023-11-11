namespace HastyBLCAdmin.Models
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public string? UserEmail { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
        public List<CommentViewModel>? Comments { get; set; }
    }
}
