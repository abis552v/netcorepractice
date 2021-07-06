using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace myapp.Models
{

    public class ApplicationUser : IdentityUser
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public DateTime DateOfBirth {get;set;}
    }
    
}