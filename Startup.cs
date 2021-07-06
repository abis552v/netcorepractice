using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using myapp.Data;
using myapp.Models;
using myapp.Repository;
using myapp.Helpers;

namespace myapp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration config)
        {
            _configuration = config;
        }
        
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ExpenseManagerContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            
            services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<ExpenseManagerContext>();

            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
            });
            
            services.AddControllersWithViews();
        
        #if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
        #endif

            services.AddScoped<IExpenseRepository,ExpenseRepository>();
            services.AddScoped<IAccountRepository,AccountRepository>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!");
                // });
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
