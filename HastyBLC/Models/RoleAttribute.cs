using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastyBLC.Models
{
    public class RoleAttribute
    {
        [Key]
        public int RoleAttributeId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        [ForeignKey("Attribute")]
        public int AttributeId { get; set; }
        public Attribute? Attribute { get; set; }
    }
}
