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

            if (!context.LegalServiceGroups.Any())
            {
                context.LegalServiceGroups.AddRange(
                    new LegalServiceGroup
                    {
                        //LegalServiceGroupId = 1,
                        GroupName = "Консультации"
                    },
                    new LegalServiceGroup
                    {
                        //LegalServiceGroupId = 2,
                        GroupName = "Составление документов"
                    },
                    new LegalServiceGroup
                    {
                        //LegalServiceGroupId = 3,
                        GroupName = "Судебное представительство"
                    });
                await context.SaveChangesAsync();
            }

            if (!context.LegalServices.Any())
            {
                context.LegalServices.AddRange(
                    new LegalService
                    {
                        //LegalServiceId = 1,
                        Name = "Консультация по семейному праву",
                        Description = "Разъяснение по вопросам расторжения брака и раздела имущества",
                        Price = 50M,
                        LegalServiceGroupId = 1,
                        Image = "consult.jpg"
                    },
                    new LegalService
                    {
                        //LegalServiceId = 2,
                        Name = "Консультация по жилищному праву",
                        Description = "Разъяснение по вопросам выселения из квартиры или дома",
                        Price = 50M,
                        LegalServiceGroupId = 1,
                        Image = "consult.jpg"
                    },
                    new LegalService
                    {
                        //LegalServiceId = 3,
                        Name = "Составление искового заявления по семейному спору",
                        Description = "Исковые заявления по делам, возникающим из семейных правоотношений",
                        Price = 200M,
                        LegalServiceGroupId = 2,
                        Image = "document.jpg"
                    },
                    new LegalService
                    {
                        //LegalServiceId = 4,
                        Name = "Составление искового заявления по жилищному спору",
                        Description = "Исковые заявления по делам, возникающим из жилищных правоотношений",
                        Price = 200M,
                        LegalServiceGroupId = 2,
                        Image = "document.jpg"
                    },
                    new LegalService
                    {
                        //LegalServiceId = 5,
                        Name = "Представительство по семейным делам в суде",
                        Description = "Участие в качестве представителя по семейным делам в суде",
                        Price = 250M,
                        LegalServiceGroupId = 3,
                        Image = "court.jpg"
                    },
                    new LegalService
                    {
                        //LegalServiceId = 6,
                        Name = "Представительство по жилищным делам в суде",
                        Description = "Участие в качестве представителя по семейным делам в суде",
                        Price = 250M,
                        LegalServiceGroupId = 3,
                        Image = "court.jpg"
                    },
                    new LegalService
                    {
                        //LegalServiceId = 7,
                        Name = "Консультация по семейному праву",
                        Description = "Разъяснение по вопросам расторжения брака и раздела имущества",
                        Price = 50M,
                        LegalServiceGroupId = 1,
                        Image = "consult.jpg"
                    },
                    new LegalService
                    {
                        //LegalServiceId = 8,
                        Name = "Консультация по жилищному праву",
                        Description = "Разъяснение по вопросам выселения из квартиры или дома",
                        Price = 50M,
                        LegalServiceGroupId = 1,
                        Image = "consult.jpg"
                    });
                await context.SaveChangesAsync();
            }
        }
    }
}
