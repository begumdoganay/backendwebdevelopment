using Serilog;
using BookStore_Web_Application.API.Middleware;
using BookStore_Web_Application.Application;
using BookStore_Web_Application.Infrastructure;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Infrastructure.Data.Seed;
using BookStore_Web_Application.Infrastructure.Settings;
using BookStore_Web_Application.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Serilog yapýlandýrmasý
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("logs/bookstore-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger ayarlarý
builder.Services.AddSwaggerGen(c =>
{

    // Swagger'a JWT Bearer token eklemek için
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by a space and then your JWT token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Application ve Infrastructure servislerini ekle
builder.Services.AddApplication();
await builder.Services.AddInfrastructureAsync(builder.Configuration);
// CORS politikasý - mevcut kod ayný kalacak
builder.Services.AddCors(options =>
{
    // ... mevcut CORS konfigürasyonu
});

var app = builder.Build();

// Seed data - mevcut kod ayný kalacak
using (var scope = app.Services.CreateScope())
{
    // ... mevcut seed kodu
}

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API v1"));
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseCors("AllowAll");

// Authentication ve Authorization middleware'leri
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();