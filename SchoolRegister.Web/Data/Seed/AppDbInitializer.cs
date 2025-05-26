using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Web.Data.Seed
{
    public static class AppDbInitializer
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

            // Jeśli rola już istnieje, nie tworzymy jej ponownie
            if (!dbContext.Roles.Any(r => r.RoleValue == RoleValue.Admin))
            {
                var adminRole = new Role()
                {
                    Id = 4,
                    Name = "Admin",
                    RoleValue = RoleValue.Admin
                };
                await roleManager.CreateAsync(adminRole);
            }

            var userPassword = "User1234";
            var email = "a1@eg.eg";

            var existingUser = await userManager.FindByEmailAsync(email);
            if (existingUser == null)
            {
                var a1 = new User()
                {
                    Id = 11,
                    FirstName = "Jacek",
                    LastName = "Kowalczyk",
                    UserName = email,
                    Email = email,
                    RegistrationDate = new DateTime(2009, 1, 1)
                };

                await userManager.CreateAsync(a1, userPassword);
                await userManager.AddToRoleAsync(a1, "Admin");
            }
        }

    }
}