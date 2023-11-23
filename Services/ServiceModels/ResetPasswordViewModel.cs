using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string? UserId { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("NewPassword", ErrorMessage = "Password and Confirmation Password must match.")]
        public string? ConfirmNewPassword { get; set; }

        public string? Code { get; set; }
    }


}
