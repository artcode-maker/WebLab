using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab.Services;
using WebLab.DAL.Data;
using WebLab.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace WebLab.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                await roleManager.CreateAsync(roleAdmin);
            }

            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");

                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");

                admin = await userManager.FindByNameAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            };
        }
    }
}
