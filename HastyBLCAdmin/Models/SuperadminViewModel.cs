using Microsoft.AspNetCore.Identity;

namespace HastyBLCAdmin.Models
{
    public class SuperadminViewModel
    {
        public List<IdentityRole>? Roles { get; set; }
    }
}
