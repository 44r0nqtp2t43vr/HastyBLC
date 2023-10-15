using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Data.Models
{
    public partial class User
    {
        [Key]
        public int UserId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? CreatedBy {  get; set; }
        public DateTime CreatedTime {  get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedTime { get; set; }
        public ICollection<UserRoleAttribute>? UserRoleAttributes { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
