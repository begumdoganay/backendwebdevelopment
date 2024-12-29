using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Identity.API.Models;
using System;
using System.Data;

namespace Identity.API.Datas
{

        // Database context for the identity system, inheriting from IdentityDbContext.
        // This context manages user and role entities and their associated data.

        public class Context : IdentityDbContext<User, Role, Guid>
        {

            // Initializes a new instance of the Context class.
            // <param name="options">Database context options, including connection string and provider.</param>
            public Context(DbContextOptions<Context> options) : base(options)
            {
            }

            // Configures the model creating process.
            // This method is called when the model for a context is being created.
            // <param name="builder">Model builder to configure the entities and relationships.</param>
            protected override void OnModelCreating(ModelBuilder builder)
            {
                // Call the base method to apply default configurations provided by IdentityDbContext
                base.OnModelCreating(builder);

                // Configure the custom tables for identity-related entities
                builder.Entity<User>().ToTable("Users"); // Maps User entity to Users table
                builder.Entity<Role>().ToTable("Roles"); // Maps Role entity to Roles table
                builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles"); // Maps UserRole entity to UserRoles table
                builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims"); // Maps UserClaim entity to UserClaims table
                builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins"); // Maps UserLogin entity to UserLogins table
                builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims"); // Maps RoleClaim entity to RoleClaims table
                builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens"); // Maps UserToken entity to UserTokens table

                // Configure additional properties or relationships as needed
                ConfigureUserEntity(builder);
                ConfigureRoleEntity(builder);

                // Global query filters can be defined here if needed
                // Example: builder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            }

            // Configures properties and relationships for the User entity.
            // <param name="builder">Model builder to configure the User entity.</param>
            private void ConfigureUserEntity(ModelBuilder builder)
            {
                // Customize the User entity configuration, such as field lengths, required fields, etc.
                builder.Entity<User>()
                    .Property(u => u.Email)
                    .IsRequired() // Ensure Email is required
                    .HasMaxLength(256); // Set maximum length for Email

                builder.Entity<User>()
                    .Property(u => u.UserName)
                    .IsRequired() // Ensure UserName is required
                    .HasMaxLength(256); // Set maximum length for UserName

                // Additional user-specific configurations can be added here
            }


            // Configures properties and relationships for the Role entity.
            // <param name="builder">Model builder to configure the Role entity.</param>

            private void ConfigureRoleEntity(ModelBuilder builder)
            {
                // Customize the Role entity configuration, such as field lengths, required fields, etc.
                builder.Entity<Role>()
                    .Property(r => r.Name)
                    .IsRequired() // Ensure Role Name is required
                    .HasMaxLength(256); // Set maximum length for Role Name

                // Additional role-specific configurations can be added here
            }
        }
    
}
