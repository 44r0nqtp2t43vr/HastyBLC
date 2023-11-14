using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceModels
{
    public class AspNetRoleViewModel
    {
        public string? RoleId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
    }
}
