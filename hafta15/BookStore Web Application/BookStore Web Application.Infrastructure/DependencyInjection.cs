using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Interfaces.Authentication;
using BookStore_Web_Application.Core.Interfaces.Repositories;
using BookStore_Web_Application.Core.Interfaces.Services; // IEmailService için
using BookStore_Web_Application.Core.Settings;
using BookStore_Web_Application.Infrastructure.Authentication;
using BookStore_Web_Application.Infrastructure.Data.Context;
using BookStore_Web_Application.Infrastructure.Data.Repositories;
using BookStore_Web_Application.Infrastructure.Data.Seed;
using BookStore_Web_Application.Infrastructure.Services;
using MailChimp.Net.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer; // JwtBearerDefaults için
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens; // TokenValidationParameters ve SymmetricSecurityKey için
using System.Text;

namespace BookStore_Web_Application.Infrastructure
{
    public static class DependencyInjection
    {
        public static async Task<IServiceCollection> AddInfrastructureAsync(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            {
                services.AddDbContext<BookStoreDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(BookStoreDbContext).Assembly.FullName)));

                services.AddIdentity<User, Role>(options =>
                {
                    // Şifre politikaları
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.User.RequireUniqueEmail = true;

                    // Kullanıcı politikaları
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<BookStoreDbContext>()
                .AddDefaultTokenProviders();

                // JWT Authentication
                var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>() ?? throw new InvalidOperationException("JwtSettings section is missing or invalid.");
                services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
                services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
                services.AddScoped<IIdentityService, IdentityService>();
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                });

                // Repository Registrations
                services.AddScoped<IBookRepository, BookRepository>();
                services.AddScoped<IAuthorRepository, AuthorRepository>();
                services.AddScoped<ICategoryRepository, CategoryRepository>();

                // Service Registrations
                services.AddScoped<IEmailService, EmailService>();
               // services.AddScoped<ICacheService, CacheService>();
                services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
                services.AddScoped<IIdentityService, IdentityService>();
                // Seed işlemini burada çağırın
                using (var scope = services.BuildServiceProvider().CreateScope())
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                    await DefaultUsers.SeedAsync(userManager, roleManager);
                }

                return services;
            }
        }
    }
}
