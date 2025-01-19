
using BookStore_Web_Application.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookStore_Web_Application.Infrastructure.Data.Seed
{
    public static class DefaultUsers
    {
        public static async Task SeedAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            // Admin rolünü oluştur
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new Role { Name = "Admin" });
            }

            // User rolünü oluştur
            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new Role { Name = "User" });
            }

            // Admin kullanıcısını oluştur
            var adminUser = new User
            {
                UserName = "admin@bookstore.com",
                Email = "admin@bookstore.com",
                FirstName = "Admin",
                LastName = "User",
                EmailConfirmed = true
            };

            if (await userManager.FindByEmailAsync(adminUser.Email) == null)
            {
                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

    }
}