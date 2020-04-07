using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.ViewModels.Accounts
{
    public class RegisterViewModel
    {
        [Required]
        [Remote("UserNameExists", "Account", HttpMethod = "POST")]
        [StringLength(100, ErrorMessage = "UserName must be at least 4 characters long", MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name must be at least 4 characters long", MinimumLength = 4)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "EIN")]
        [RegularExpression(@"^[0-9]{2}-[0-9]{7}$", ErrorMessage = "EIN number must follow the XX-XXXXXXX pattern")]
        public string Ein { get; set; }

        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{2}$", ErrorMessage = "Post code must follow the XXX-XXX-XX pattern")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [Remote("EmailExists", "Account", HttpMethod = "POST")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password must be between 4 and 50 characters long", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
