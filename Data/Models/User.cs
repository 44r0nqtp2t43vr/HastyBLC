using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Data.Models
{
    public partial class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? CreatedBy {  get; set; }
        public DateTime CreatedTime {  get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }

    }
}
