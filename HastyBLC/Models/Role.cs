using System.ComponentModel.DataAnnotations;

namespace HastyBLC.Models
{
    public class Role
    {
        [Key]
        public int RoleId {  get; set; }
        public string? Name { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<RoleAttribute>? RoleAttributes { get; set; }

    }
}
