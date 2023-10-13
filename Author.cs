using System.Collections.Generic;

namespace SharedModels
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string? Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}