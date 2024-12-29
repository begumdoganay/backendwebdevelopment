using JWT_API.Datas;
using JWT_API.DTOs;
using JWT_API.HelperFunctions;
using JWT_API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddLogging(configure => configure.AddConsole());

// Configure in-memory database for development/testing purposes.
builder.Services.AddDbContext<Context>(opts =>
{
    opts.UseInMemoryDatabase("Week-14-JWT.API");
});

// Configure Identity services.
builder.Services.AddIdentity<User, Role>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequireDigit = true;
    opts.Password.RequireLowercase = true;
    opts.Password.RequireUppercase = true;
    opts.Password.RequireNonAlphanumeric = true;
    opts.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<Context>()
.AddDefaultTokenProviders();

// Register custom services.
builder.Services.AddScoped<TokenService>();
builder.Services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOptions"));

// Retrieve token options from configuration.
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<CustomTokenOptions>();

// Configure JWT authentication.
builder.Services.AddAuthentication(opts =>
{
    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = tokenOptions!.Audience[0],
        ValidIssuer = tokenOptions.Issuer,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
        ClockSkew = TimeSpan.Zero // No delay before token expiration
    };
});

// Configure Swagger for API documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed the database with initial data.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    var db = services.GetRequiredService<Context>();
    try
    {
        // Uncomment the following line if using migrations with a real database.
        // await db.Database.MigrateAsync();

        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<Role>>();
        IdentitySeed.Seed(userManager, roleManager);
        logger.LogInformation("Database migrated and seeded successfully.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
        // Uncomment for real database transactions.
        // await db.Database.RollbackTransactionAsync();
        // await db.Database.EnsureDeletedAsync();
        throw;
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Run the application.
app.Run();