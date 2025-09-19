using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AzureBootCamp.Models
{
    public class ForgotPassword
    {
        public string UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Min 5 characters required")]
        [MaxLength(15, ErrorMessage = "Max 15 characters allowed")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [MinLength(5, ErrorMessage = "Min 5 characters required")]
        [MaxLength(15, ErrorMessage = "Max 15 characters allowed")]
        public string ConfirmPassword { get; set; }
    }
}
