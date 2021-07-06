using System;
using System.ComponentModel.DataAnnotations;
using myapp.Models;

namespace myapp.Data
{
    public class Expenses
    {
        [Key]
        public int Id {get;set;}

        public string ExpenseName {get;set;}
        public DateTime Date {get;set;}
        public ExpenseType ExpenseType {get;set;}

        public double Amount {get;set;}
    }
}

   