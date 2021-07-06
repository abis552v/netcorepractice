using System;
using Microsoft.AspNetCore.Mvc;
using myapp.Data;
using myapp.Models;

namespace myapp.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseManagerContext _context;
        public ExpenseRepository(ExpenseManagerContext context)
        {
            _context = context;
        }

        public int AddNewExpense(ExpenseModel model)
        {
            var newExpense = new Expenses()
            {
                Amount = model.Amount,
                ExpenseName = model.ExpenseName,
                ExpenseType = model.ExpenseType,
                Date = model.Date
            };

            _context.Expenses.Add(newExpense);
            _context.SaveChanges();

            return newExpense.Id;
        }
    }

}