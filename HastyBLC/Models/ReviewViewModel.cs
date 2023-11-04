namespace HastyBLC.Models
{
    public class ReviewViewModel
    {
        public int BookId { get; set; }
        public string? BookTitle { get; set; }
        public int Stars { get; set; }
        public string? Comment { get; set; }
    }
}
