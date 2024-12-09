using CodeFirstRelationProject.Model.Context;
using CodeFirstRelationProject.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CodeFirstRelationProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CodeFirstDbContext())
            {
                try
                {
                    // Veritabanýný oluþtur
                    context.Database.EnsureCreated();
                    Console.WriteLine("Veritabaný baþarýyla oluþturuldu!");

                    // Örnek kullanýcý ekleme
                    AddSampleUser(context);

                    // Örnek post ekleme
                    AddSamplePost(context);

                    // Verileri listeleme
                    ListAllData(context);

                    Console.WriteLine("\nTüm iþlemler baþarýyla tamamlandý!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Bir hata oluþtu: {ex.Message}");
                }
            }

            Console.WriteLine("\nÇýkmak için bir tuþa basýn...");
            Console.ReadKey();
        }

        static void AddSampleUser(CodeFirstDbContext context)
        {
            // Kullanýcý daha önce eklenmemiþse ekle
            if (!context.Users.Any(u => u.Email == "test@example.com"))
            {
                var user = new User
                {
                    Username = "testuser",
                    Email = "test@example.com",
                    Password = "test123",
                    FirstName = "Test",
                    LastName = "User",
                    IsActive = true
                };

                context.Users.Add(user);
                context.SaveChanges();
                Console.WriteLine("Örnek kullanýcý eklendi.");
            }
        }

        static void AddSamplePost(CodeFirstDbContext context)
        {
            // Ýlk kullanýcýyý bul
            var user = context.Users.FirstOrDefault();
            if (user != null)
            {
                var post = new Post
                {
                    Title = "Test Post",
                    Content = "Bu bir test post içeriðidir.",
                    UserId = user.Id,
                    IsActive = true
                };

                context.Posts.Add(post);
                context.SaveChanges();
                Console.WriteLine("Örnek post eklendi.");
            }
        }

        static void ListAllData(CodeFirstDbContext context)
        {
            Console.WriteLine("\n--- Kullanýcýlar ---");
            foreach (var user in context.Users.Include(u => u.Posts))
            {
                Console.WriteLine($"Kullanýcý: {user.Username}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Post Sayýsý: {user.Posts.Count}");
                Console.WriteLine("--------------------");
            }

            Console.WriteLine("\n--- Postlar ---");
            foreach (var post in context.Posts.Include(p => p.User))
            {
                Console.WriteLine($"Baþlýk: {post.Title}");
                Console.WriteLine($"Yazar: {post.User.Username}");
                Console.WriteLine($"Ýçerik: {post.Content}");
                Console.WriteLine("--------------------");
            }
        }
    }
}