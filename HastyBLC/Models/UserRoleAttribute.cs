using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class UserRoleAttribute
    {
        [Key]
        public int UserRoleAttributeId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
        [ForeignKey("RoleAttribute")]
        public int RoleAttributeId { get; set; }
        public RoleAttribute? RoleAttribute { get; set; }
        public string? Value { get; set; }

    }
}
