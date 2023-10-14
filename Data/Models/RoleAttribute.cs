using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class RoleAttribute
    {
        [Key]
        public int RoleAttributeId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        [ForeignKey("Attribute")]
        public int AttributeId { get; set; }
        public Attribute? Attribute { get; set; }
        public ICollection<UserRoleAttribute>? UserRoleAttributes { get; set; }
    }
}

