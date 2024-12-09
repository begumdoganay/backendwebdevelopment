Week 12 - Entity Framework Core Code First Relations
This project demonstrates the implementation of database relationships using Entity Framework Core's Code First approach. It creates a simple blog-like database structure with users and their posts.
Project Structure
Database Schema

Users Table

Id (int): Primary key, auto-increment
Username (string): User's username
Email (string): User's email address


Posts Table

Id (int): Primary key, auto-increment
Title (string): Post title
Content (string): Post content
UserId (int): Foreign key referencing Users table



Relationships

One-to-Many relationship between User and Post
One User can have multiple Posts
Each Post belongs to exactly one User

Implementation Details
Entity Classes
csharpCopypublic class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public ICollection<Post> Posts { get; set; }
}

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
Database Context
csharpCopypublic class PatikaSecondDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=PatikaCodeFirstDb2;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Posts)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
    }
}
Setup Instructions

Install Required Packages:
CopyInstall-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools

Run Migrations:
CopyAdd-Migration InitialCreate
Update-Database


Key Features

Code First Approach

Database schema is defined using C# classes
Relationships are configured using Fluent API
Automatic database creation and updates


Data Annotations

Primary keys are defined
Navigation properties for relationships
Foreign key constraints


Entity Framework Features

Automatic key generation
Relationship navigation
Database context configuration



Usage Example
csharpCopyusing (var context = new PatikaSecondDbContext())
{
    // Create a new user
    var user = new User 
    { 
        Username = "johndoe", 
        Email = "john@example.com" 
    };
    
    // Add user to database
    context.Users.Add(user);
    context.SaveChanges();

    // Create a post for the user
    var post = new Post
    {
        Title = "My First Post",
        Content = "Hello World!",
        UserId = user.Id
    };
    
    // Add post to database
    context.Posts.Add(post);
    context.SaveChanges();
}
Database Configuration

Database Name: PatikaCodeFirstDb2
Tables:

Users
Posts


Context Class: PatikaSecondDbContext

Notes

Ensure SQL Server is installed and running
Check connection string matches your SQL Server instance
Make sure you have necessary permissions to create database
Run migrations before using the application

Additional Resources

Entity Framework Core Documentation
Code First Approach Guide
Relationships in EF Core