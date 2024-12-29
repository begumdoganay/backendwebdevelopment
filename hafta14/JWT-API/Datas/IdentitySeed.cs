using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using JWT_API.Models;

namespace JWT_API.Datas
{

    // Veritabanı başlangıç verilerini yüklemek için kullanılan statik sınıf

    public static class IdentitySeed
    {
        
        // Varsayılan rolleri ve admin kullanıcısını oluşturur
      
        public static async Task SeedAsync(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IConfiguration configuration)
        {
            // Uygulama rollerini tanımla
            var defaultRoles = new Dictionary<string, string>
            {
                { "Admin", "Tam yetkili sistem yöneticisi" },
                { "Manager", "Kısıtlı yetkili yönetici" },
                { "User", "Standart kullanıcı" }
            };

            // Rolleri oluştur
            foreach (var role in defaultRoles)
            {
                if (!await roleManager.RoleExistsAsync(role.Key))
                {
                    var newRole = new Role
                    {
                        Name = role.Key,
                        Description = role.Value,
                        CreatedDate = DateTime.UtcNow
                    };
                    var createRoleResult = await roleManager.CreateAsync(newRole);

                    if (!createRoleResult.Succeeded)
                    {
                        throw new Exception($"Rol oluşturma hatası: {role.Key}");
                    }
                }
            }

            // Admin kullanıcısı için bilgileri config'den al
            var adminEmail = configuration["AdminUser:Email"] ?? "admin@gmail.com";
            var adminUserName = configuration["AdminUser:UserName"] ?? "Alparslan";
            var adminPassword = configuration["AdminUser:Password"] ?? "A.lparslan123";

            // Admin kullanıcısını oluştur
            var adminUser = new User
            {
                Id = Guid.NewGuid(),
                UserName = adminUserName,
                Email = adminEmail,
                EmailConfirmed = true,
                CreatedDate = DateTime.UtcNow,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            // Admin kullanıcısının varlığını kontrol et
            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);

            if (existingAdmin == null)
            {
                try
                {
                    var createUserResult = await userManager.CreateAsync(adminUser, adminPassword);
                    if (createUserResult.Succeeded)
                    {
                        // Admin rolünü ata
                        var addToRoleResult = await userManager.AddToRoleAsync(adminUser, "Admin");
                        if (!addToRoleResult.Succeeded)
                        {
                            throw new Exception("Admin rolü atama hatası");
                        }

                        // Ekstra Manager rolü de ekle
                        await userManager.AddToRoleAsync(adminUser, "Manager");
                    }
                    else
                    {
                        var errors = string.Join(", ", createUserResult.Errors.Select(e => e.Description));
                        throw new Exception($"Admin kullanıcı oluşturma hatası: {errors}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Seed işlemi sırasında hata: {ex.Message}");
                }
            }
        }

        internal static void Seed(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            throw new NotImplementedException();
        }
    }
}