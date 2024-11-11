using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Add session service with custom configurations
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession(); // Enables session state
app.UseRouting();

// Custom middleware for logging requests
app.Use(async (context, next) =>
{
    var requestPath = context.Request.Path;
    Console.WriteLine($"Request Path: {requestPath} - Time: {DateTime.Now}");
    await next();
});

// Default route configuration
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

/*
DETAILED EXPLANATIONS:

1. MVC Architecture Components:
   - Model: Represents data structure and business logic.
   - View: Handles the UI and presentation logic.
   - Controller: Manages user input and responses.

2. Key Concepts:
   - Controller: A class that handles HTTP requests and manages application logic.
   - Action: Methods within controllers that respond to user requests.
   - View: Razor pages (.cshtml) that render HTML content.
   - Model: Classes that represent data and business logic.
   - Route: URL pattern that maps to specific controller actions.

3. Important Methods:
   - builder.Build(): Constructs the application with configured services.
   - app.Run(): Starts the web application and listens for HTTP requests.
   - MapControllerRoute(): Defines URL patterns for routing.

4. Middleware Components:
   - UseStaticFiles(): Enables serving static files from wwwroot.
   - UseRouting(): Enables routing capabilities.
   - UseSession(): Enables session state.
   - UseHttpsRedirection(): Redirects HTTP requests to HTTPS.

5. Environment-specific Configuration:
   - Development: Shows detailed error pages.
   - Production: Uses error handling and HSTS.
*/
