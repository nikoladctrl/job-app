using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japp.Core.Entities;
using Japp.EFCore.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Japp.EFCore.Seeders
{
    public class DbSeeder
    {
        public static async void Initialize(DataContext context, IServiceProvider services, UserManager<Member> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Get a logger
            var logger = services.GetRequiredService<ILogger<DbSeeder>>();

            // Make sure the database is created
            // We already did this in the previous step
            context.Database.EnsureCreated();

            var roles = new List<IdentityRole>
            {
                new IdentityRole() { Name = "Admin" },
                new IdentityRole() { Name = "Member" }
            };

            foreach(var role in roles)
            {
                var roleExists = await roleManager.RoleExistsAsync(role.Name);

                if (!roleExists) {
                    await roleManager.CreateAsync(role);
                }
            }

            var admin = await userManager.Users.FirstOrDefaultAsync(u => u.UserName == "Administrator");

            if (admin == null)
            {
                admin = new Member
                {
                    FirstName = "Admin Name",
                    LastName = "Admin Surname",
                    UserName = "Administrator",
                    Email = "administrator@test.com"
                };
                var password = "mySecretPassword1!";
                await userManager.CreateAsync(admin, password);
                await userManager.AddToRolesAsync(admin, new [] { "Admin" });
            }

            var categories = await context.Categories.ToListAsync();
            if (categories == null) {
                categories.Add(new Category { Name = "Programming" });
                categories.Add(new Category { Name = "System administration" });
                categories.Add(new Category { Name = "Management" });
                categories.Add(new Category { Name = "QA" });
                categories.Add(new Category { Name = "Sales/Consulting" });
                categories.Add(new Category { Name = "Support" });
                categories.Add(new Category { Name = "UX Design" });
                categories.Add(new Category { Name = "Internships" });
            }

            context.SaveChanges();

            logger.LogInformation("Finished seeding the database.");
        }
    }
}