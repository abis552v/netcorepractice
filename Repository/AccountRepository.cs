using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using myapp.Data;
using myapp.Models;

namespace myapp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser(){
                Email = userModel.Email,
                UserName = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                DateOfBirth = userModel.DateOfBirth
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
            return signInResult;
        }

        public async Task SignOutAsync()
        {
           await _signInManager.SignOutAsync();
        }

    }
}