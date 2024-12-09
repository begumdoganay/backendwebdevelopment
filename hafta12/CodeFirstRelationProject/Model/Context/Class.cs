using CodeFirstRelationProject.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstRelationProject.Model.Context
{
    public class CodeFirstDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GIZEM\\SQLEXPRESS;Initial Catalog=PatikaSecondDbContext;Integrated Security=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();


                entity.HasData(new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@example.com",
                    Password = "admin123",
                    FirstName = "Admin",
                    LastName = "User",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
            });


            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Posts");

                // User-Post ilişkisi
                entity.HasOne(p => p.User)
                      .WithMany(u => u.Posts)
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Restrict);


                entity.HasData(new Post
                {
                    Id = 1,
                    Title = "İlk Post",
                    Content = "Merhaba Dünya!",
                    UserId = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                });
            });
        }


        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}