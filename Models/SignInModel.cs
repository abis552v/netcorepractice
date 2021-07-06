using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace myapp.Models
{

    public class SignInModel
    {
        [Required]
        [Display(Name = "Email Address")]
        public string Email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        [Display(Name = "Remember me")]
        public bool RememberMe {get;set;}
    
    }
}