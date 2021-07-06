using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace myapp.Models
{

    public class ExpenseModel
    {
        [Required]
        public string ExpenseName {get;set;}
        [Required]
        public DateTime Date {get;set;}
        [Required]
        public ExpenseType ExpenseType {get;set;}
        [Required]
        public double Amount {get;set;}
    }

    public enum ExpenseType{
        
        [Display(Name = "Mutual Fund Investment")]
        INV_MF = 0,
        [Display(Name = "RD Investment")]
        INV_RD = 1,
        [Display(Name = "ULIP Investment")]
        INV_ULIP = 2,
        [Display(Name = "Expense")]
        EXP = 3
    }
}