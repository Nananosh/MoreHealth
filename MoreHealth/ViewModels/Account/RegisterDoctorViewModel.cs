using System;
using System.ComponentModel.DataAnnotations;

namespace MoreHealth.ViewModels.Account
{
    public class RegisterDoctorViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat the password")]
        public string PasswordConfirm { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        
        [Required]
        [Display(Name = "LastName")]
        public string Lastname { get; set; }
        
    }
}