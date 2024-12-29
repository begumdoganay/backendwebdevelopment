using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using JWT_API.Models;

namespace JWT_API.Datas
{

    // Database context class that extends IdentityDbContext for handling authentication and authorization
    // User and Role entities use Guid as the key type

    public class Context(DbContextOptions options) : IdentityDbContext<User, Role, Guid>(options)
    {


        // Configure the database model and customize table names for Identity tables

        // <param name="builder">ModelBuilder instance for configuring the database schema</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Call base configuration first to set up Identity tables
            base.OnModelCreating(builder);

            // Customize table names for better readability and organization

            // Main entity tables
            builder.Entity<User>().ToTable("Users");         // Custom Users table name
            builder.Entity<Role>().ToTable("Roles");         // Custom Roles table name

            // Relationship and auxiliary tables
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");           // Links users to their roles
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");         // Stores user claims
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");         // Stores user login information
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");         // Stores role claims
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");         // Stores user tokens
        }
    }
}

