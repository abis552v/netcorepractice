using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using myapp.Models;

namespace myapp.Data
{
    public class ExpenseManagerContext : IdentityDbContext<ApplicationUser>
    {
        public ExpenseManagerContext(DbContextOptions<ExpenseManagerContext> options) : base(options)
        {
        }
        public DbSet<Expenses> Expenses {get;set;}
    }

}