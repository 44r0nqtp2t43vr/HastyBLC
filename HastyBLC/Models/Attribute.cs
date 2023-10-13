using System.ComponentModel.DataAnnotations;

namespace HastyBLC.Models
{
    public class Attribute
    {
        [Key]
        public int AttributeId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public ICollection<RoleAttribute>? RoleAttributes { get; set; }
    }
}
