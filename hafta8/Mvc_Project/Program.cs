// Modern Dijital Çözüm Platformu Namespace alaný
namespace Mvc_Project
{
    // Akýllý Uygulama Baþlatýcýsý
    public class SmartApplicationBootstrapper
    {
        // Geliþmiþ Baþlatma Metodu
        public static void InitializeDigitalEcosystem(string[] environmentParameters)
        {
            // Çevre ve Altyapý Hazýrlayýcýsý
            var infrastructureBuilder = WebApplication.CreateBuilder(
                new WebApplicationOptions
                {
                    ApplicationName = "Week8_2_ModernMvcPlatform",
                    EnvironmentName = Environments.Development
                }
            );

            // Akýllý Servis Konfigürasyonlarý
            ConfigureIntelligentServices(infrastructureBuilder);

            // Uygulama Örneðini Oluþtur
            var digitalPlatform = infrastructureBuilder.Build();

            // Geliþmiþ Middleware Zincirleri
            ConfigureMiddlewarePipeline(digitalPlatform);

            // Rotalama Stratejilerini Tanýmla
            DefineRoutingStrategies(digitalPlatform);

            // Platformu Baþlat
            digitalPlatform.Run();
        }

        // Akýllý Servis Yapýlandýrýcýsý
        private static void ConfigureIntelligentServices(WebApplicationBuilder builder)
        {
            // MVC Yapýlandýrmasý
            builder.Services.AddControllersWithViews(options =>
            {
                // Geliþmiþ MVC Konfigürasyonlarý
                options.EnableEndpointRouting = true;
            });

            // Performans ve Güvenlik Ýyileþtirmeleri
            builder.Services.AddMemoryCache();
            builder.Services.AddResponseCompression();
        }

        // Middleware Hattý Konfigürasyonu
        private static void ConfigureMiddlewarePipeline(WebApplication app)
        {
            // Geliþtirme Ortamý Hata Yönetimi
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                // Üretim Ortamý Güvenlik Ayarlarý
                app.UseHsts();
                app.UseExceptionHandler("/SystemError");
            }

            // Güvenlik ve Performans Middleware'leri
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseResponseCompression();
        }

        // Dinamik Rotalama Stratejisi
        private static void DefineRoutingStrategies(WebApplication app)
        {
            // Ana Ýþ Akýþ Rotasý
            app.MapControllerRoute(
                name: "primaryWorkflow",
                pattern: "{controller=CustomerOrders}/{action=Index}/{id?}",
                constraints: new { id = @"\d+" }  // Sadece sayýsal ID'ler
            );

            // Alternatif Rota Desenleri
            app.MapControllerRoute(
                name: "secondaryWorkflow",
                pattern: "api/{controller}/{action}/{token?}"
            );
        }
    }

    // Giriþ Noktasý Sýnýfý
    public static class DigitalPlatformEntryPoint
    {
        public static void Main(string[] args)
        {
            // Dijital Ekosistemi Baþlat
            SmartApplicationBootstrapper.InitializeDigitalEcosystem(args);
        }
    }
}