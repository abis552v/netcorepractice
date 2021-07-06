using System;
using Microsoft.AspNetCore.Mvc;
using myapp.Data;
using myapp.Models;

namespace myapp.Repository
{
    public interface IExpenseRepository
    {
        int AddNewExpense(ExpenseModel model);
    }
}
