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
                    // Veritaban�n� olu�tur
                    context.Database.EnsureCreated();
                    Console.WriteLine("Veritaban� ba�ar�yla olu�turuldu!");

                    // �rnek kullan�c� ekleme
                    AddSampleUser(context);

                    // �rnek post ekleme
                    AddSamplePost(context);

                    // Verileri listeleme
                    ListAllData(context);

                    Console.WriteLine("\nT�m i�lemler ba�ar�yla tamamland�!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Bir hata olu�tu: {ex.Message}");
                }
            }

            Console.WriteLine("\n��kmak i�in bir tu�a bas�n...");
            Console.ReadKey();
        }

        static void AddSampleUser(CodeFirstDbContext context)
        {
            // Kullan�c� daha �nce eklenmemi�se ekle
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
                Console.WriteLine("�rnek kullan�c� eklendi.");
            }
        }

        static void AddSamplePost(CodeFirstDbContext context)
        {
            // �lk kullan�c�y� bul
            var user = context.Users.FirstOrDefault();
            if (user != null)
            {
                var post = new Post
                {
                    Title = "Test Post",
                    Content = "Bu bir test post i�eri�idir.",
                    UserId = user.Id,
                    IsActive = true
                };

                context.Posts.Add(post);
                context.SaveChanges();
                Console.WriteLine("�rnek post eklendi.");
            }
        }

        static void ListAllData(CodeFirstDbContext context)
        {
            Console.WriteLine("\n--- Kullan�c�lar ---");
            foreach (var user in context.Users.Include(u => u.Posts))
            {
                Console.WriteLine($"Kullan�c�: {user.Username}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Post Say�s�: {user.Posts.Count}");
                Console.WriteLine("--------------------");
            }

            Console.WriteLine("\n--- Postlar ---");
            foreach (var post in context.Posts.Include(p => p.User))
            {
                Console.WriteLine($"Ba�l�k: {post.Title}");
                Console.WriteLine($"Yazar: {post.User.Username}");
                Console.WriteLine($"��erik: {post.Content}");
                Console.WriteLine("--------------------");
            }
        }
    }
}