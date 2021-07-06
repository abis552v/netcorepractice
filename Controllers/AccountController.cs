using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myapp.Models;
using myapp.Repository;

namespace myapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;

        }

        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
                if(!result.Succeeded)
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                    return View();
                }
                ModelState.Clear();
            }
            return View();
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                ModelState.AddModelError("", "Invalid credentials");
                
            }

            return View(signInModel);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

    }

    
}

