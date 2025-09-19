using AzureBootCamp.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AzureBootCamp.Models
{
    public class RegisterUser
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Only alphabets allowed")]
        public string Name { get; set; }
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
        [Required]
        public string Country { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Experience { get; set; }
        [Required]
        public string[] Tracks { get; set; }

        public virtual Track Track { get; set; }
    }
}
