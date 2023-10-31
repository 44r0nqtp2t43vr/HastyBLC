﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HastyBLCAdmin.Models
{
    /// <summary>
    /// Login View Model
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>ユーザーID</summary>
        [JsonPropertyName("email")]
        [Required(ErrorMessage = "Email Address is required.")]
        public string? Email { get; set; }
        /// <summary>パスワード</summary>
        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }
}
