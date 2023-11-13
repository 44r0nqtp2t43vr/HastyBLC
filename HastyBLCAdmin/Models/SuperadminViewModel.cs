using Microsoft.AspNetCore.Identity;

namespace HastyBLCAdmin.Models
{
    public class SuperadminViewModel
    {
        public List<IdentityRole>? Roles { get; set; }
        public List<IdentityUser>? Users { get; set; }
        public Dictionary<string, List<IdentityRole>>? UserRoles { get; set; }
    }
}
