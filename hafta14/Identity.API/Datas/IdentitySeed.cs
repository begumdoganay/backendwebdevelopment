using Microsoft.AspNetCore.Identity;
using Identity.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.API.Datas
{

    // Class responsible for seeding initial roles and users into the database.

    public static class IdentitySeed
    {

        // Seeds the database with default roles and an admin user if they do not already exist.
        // <param name="userManager">The UserManager service for managing user entities.</param>
        // <param name="roleManager">The RoleManager service for managing role entities.</param>

        public static async Task SeedAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            // Define the default roles to be created
            var roles = new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "User" },
                new Role { Name = "Manager" }, // Additional role example
                new Role { Name = "Guest" }    // Additional role example
            };

            // Create roles if they do not exist
            foreach (var role in roles)
            {
                await CreateRoleIfNotExists(roleManager, role);
            }

            // Create an admin user
            var adminUser = new User
            {
                Id = Guid.NewGuid(),
                UserName = "Alparslan",
                Email = "admin@gmail.com",
                PhoneNumber = "123-456-7890", // Example property
                // Additional properties can be initialized here
            };

            await CreateUserIfNotExists(userManager, adminUser, "A.lparslan123", "Admin");
        }


        // Creates a role if it does not already exist.

        // <param name="roleManager">The RoleManager instance.</param>
        // <param name="role">The role to create.</param>
        private static async Task CreateRoleIfNotExists(RoleManager<Role> roleManager, Role role)
        {
            if (!await roleManager.RoleExistsAsync(role.Name!))
            {
                var roleResult = await roleManager.CreateAsync(role);
                if (!roleResult.Succeeded)
                {
                    // Log error if role creation fails
                    Console.WriteLine($"Failed to create role '{role.Name}': {string.Join(", ", roleResult.Errors)}");
                }
                else
                {
                    Console.WriteLine($"Role '{role.Name}' created successfully.");
                }
            }
            else
            {
                Console.WriteLine($"Role '{role.Name}' already exists.");
            }
        }


        // Creates a user if they do not already exist and assigns them a role.

        // <param name="userManager">The UserManager instance.</param>
        // <param name="user">The user to create.</param>
        // <param name="password">The password for the user.</param>
        // <param name="roleName">The name of the role to assign to the user.</param>
        private static async Task CreateUserIfNotExists(UserManager<User> userManager, User user, string password, string roleName)
        {
            switch (await userManager.FindByEmailAsync(user.Email))
            {
                case not null:
                    Console.WriteLine($"User '{user.UserName}' already exists.");
                    break;
                default:
                    {
                        var userResult = await userManager.CreateAsync(user, password);
                        if (userResult.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, roleName);
                            Console.WriteLine($"User '{user.UserName}' created and added to the '{roleName}' role.");
                        }
                        else
                        {
                            // Log error if user creation fails
                            Console.WriteLine($"Failed to create user '{user.UserName}': {string.Join(", ", userResult.Errors)}");
                        }

                        break;
                    }
            }
        }
    }
}