using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using myapp.Data;
using myapp.Models;

namespace myapp.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult>  CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();
    }
}
