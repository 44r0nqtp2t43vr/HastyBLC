using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceModels
{
    public class AspNetUserRoleViewModel
    {
        public string? UserId { get; set; }
		[Required(ErrorMessage = "Name is required.")]
		public string? RoleName { get; set; }
    }
}
