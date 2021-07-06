using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace myapp.Controllers
{
  public class HomeController : Controller
  {
    private readonly IConfiguration _configuration;
     public HomeController(IConfiguration configuration)
     {
         _configuration = configuration;
     }
      public ViewResult Index()
      {
          var result = _configuration["AppName"];
          return View();
      }
  }

}