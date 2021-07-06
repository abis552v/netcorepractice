using System;
using Microsoft.AspNetCore.Mvc;
using myapp.Models;
using myapp.Repository;

namespace myapp.Controllers
{
  public class ExpenseController : Controller
  {
      private readonly IExpenseRepository _expenseRepository = null;

      public ExpenseController(IExpenseRepository repo)
      {
        _expenseRepository = repo;
      }
      
      public ViewResult Index()
      {
          return View();
      }

      public ViewResult AddNewExpense()
      {
        return View();
      }
      
      [HttpPost]
      public IActionResult AddNewExpense(ExpenseModel model)
      {
        var id = _expenseRepository.AddNewExpense(model);
        if(id > 0 )
        {
          return RedirectToAction(nameof(AddNewExpense));
        }
        return View();
      }
  }

}