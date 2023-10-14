using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public ICollection<UserRoleAttribute>? UserRoleAttributes { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
