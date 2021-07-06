using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace myapp.Models
{
    public class SignUpUserModel
    {
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please enter valid email")]
        public string Email {get;set;}
        [Required]
        [Compare("ConfirmPassword", ErrorMessage = "Password dont match")]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public DateTime DateOfBirth {get;set;}

    }
}