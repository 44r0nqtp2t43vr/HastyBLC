using System.Collections.Generic;

namespace SharedModels
{
    public class Attribute
    {
        public int AttributeId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public ICollection<RoleAttribute>? RoleAttributes { get; set; }
    }
}
