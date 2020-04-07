using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)

        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            string[] roles = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var role in roles)
            {
                var roleExist = await RoleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var admin = new AppUser
            {
                UserName = "admin",
                Email = "admin@admin.com",
                CompanyName = "admin",
                Ein = "admin"
            };

            string userPassword = "admin";
            var user = await UserManager.FindByEmailAsync("admin@admin.com");
            if (user == null)
            {
                var createAdmin = await UserManager.CreateAsync(admin, userPassword);
                if (createAdmin.Succeeded)
                {
                    await UserManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}

