using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public partial class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string? Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}