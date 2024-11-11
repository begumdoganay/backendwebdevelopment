# Week 8 - ASP.NET Core MVC Project

## Overview
This project demonstrates the implementation of a basic ASP.NET Core MVC application, focusing on fundamental concepts and best practices in web development using the MVC architectural pattern.

## Project Structure
```
AspDotNetCore/
├── Controllers/          # Contains MVC controllers
├── Models/              # Data models and ViewModels
├── Views/               # Razor views
│   ├── Home/           # Home controller views
│   ├── Shared/         # Shared layouts and partials
├── wwwroot/            # Static files (CSS, JS, images)
│   ├── css/           
│   ├── js/            
│   ├── lib/           
└── Program.cs          # Application entry point and configuration
```

## Key Components

### 1. MVC Architecture
- **Model**: Represents the data and business logic
- **View**: Handles the presentation layer (UI)
- **Controller**: Manages user input and application flow

### 2. Core Features
- Responsive design using Bootstrap
- Client-side validation
- Custom middleware for request logging
- Session management
- Error handling
- Static file serving

### 3. Technical Implementation

#### Controllers
Controllers handle HTTP requests and manage the application logic:
```csharp
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
```

#### Models
Models define the data structure and validation rules:
```csharp
public class ContactViewModel
{
    [Required]
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
}
```

#### Views
Razor views combine HTML with C# code:
```cshtml
@model HomeViewModel
<h1>@Model.Title</h1>
```

## Getting Started

### Prerequisites
- .NET 6.0 SDK or later
- Visual Studio 2022 or Visual Studio Code
- Basic understanding of C# and MVC pattern

### Installation
1. Clone the repository
```bash
git clone [repository-url]
```

2. Navigate to the project directory
```bash
cd AspDotNetCore
```

3. Restore NuGet packages
```bash
dotnet restore
```

4. Run the application
```bash
dotnet run
```

### Configuration
The application can be configured through:
- appsettings.json
- appsettings.Development.json
- Program.cs

## Key Concepts Explained

### 1. Middleware Pipeline
The middleware pipeline in Program.cs defines how the application handles HTTP requests:
```csharp
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
```

### 2. Routing
Default routing pattern:
```csharp
{controller=Home}/{action=Index}/{id?}
```
This means:
- Default controller: Home
- Default action: Index
- Optional id parameter

### 3. View Components
Reusable UI components that can be shared across views:
```csharp
public class NavigationViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
```

### 4. Static Files
Static files are served from the wwwroot directory:
- CSS files in wwwroot/css
- JavaScript files in wwwroot/js
- Third-party libraries in wwwroot/lib

## Best Practices Implemented

1. **Separation of Concerns**
   - Clear separation between Models, Views, and Controllers
   - Use of ViewModels for view-specific data

2. **Security**
   - Implementation of anti-forgery tokens
   - Secure cookie handling
   - Input validation

3. **Performance**
   - Proper use of caching
   - Minification of static files
   - Async/await pattern usage

4. **Code Organization**
   - Consistent file naming
   - Proper namespace usage
   - Clear folder structure

## Common Tasks

### Adding a New Controller
1. Create a new controller class in the Controllers folder
2. Inherit from Controller base class
3. Add action methods

### Creating a New View
1. Add a new .cshtml file in the appropriate Views folder
2. Use the @model directive if needed
3. Write HTML and Razor syntax

### Adding Static Files
1. Place files in appropriate wwwroot subdirectory
2. Reference in views using ~/path/to/file

## Troubleshooting

### Common Issues
1. **404 Errors**
   - Check routing configuration
   - Verify controller and action names

2. **500 Errors**
   - Check application logs
   - Verify database connections
   - Check for null references

3. **Static Files Not Loading**
   - Verify UseStaticFiles() is called
   - Check file paths and permissions

## Contributing
1. Fork the repository
2. Create a feature branch
3. Submit a pull request

## References
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core)
- [MVC Pattern](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview)
- [Razor Syntax](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor)
