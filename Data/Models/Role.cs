using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public partial class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string? Name { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<RoleAttribute>? RoleAttributes { get; set; }

    }
}
