// Modern Dijital ��z�m Platformu Namespace alan�
namespace Mvc_Project
{
    // Ak�ll� Uygulama Ba�lat�c�s�
    public class SmartApplicationBootstrapper
    {
        // Geli�mi� Ba�latma Metodu
        public static void InitializeDigitalEcosystem(string[] environmentParameters)
        {
            // �evre ve Altyap� Haz�rlay�c�s�
            var infrastructureBuilder = WebApplication.CreateBuilder(
                new WebApplicationOptions
                {
                    ApplicationName = "Week8_2_ModernMvcPlatform",
                    EnvironmentName = Environments.Development
                }
            );

            // Ak�ll� Servis Konfig�rasyonlar�
            ConfigureIntelligentServices(infrastructureBuilder);

            // Uygulama �rne�ini Olu�tur
            var digitalPlatform = infrastructureBuilder.Build();

            // Geli�mi� Middleware Zincirleri
            ConfigureMiddlewarePipeline(digitalPlatform);

            // Rotalama Stratejilerini Tan�mla
            DefineRoutingStrategies(digitalPlatform);

            // Platformu Ba�lat
            digitalPlatform.Run();
        }

        // Ak�ll� Servis Yap�land�r�c�s�
        private static void ConfigureIntelligentServices(WebApplicationBuilder builder)
        {
            // MVC Yap�land�rmas�
            builder.Services.AddControllersWithViews(options =>
            {
                // Geli�mi� MVC Konfig�rasyonlar�
                options.EnableEndpointRouting = true;
            });

            // Performans ve G�venlik �yile�tirmeleri
            builder.Services.AddMemoryCache();
            builder.Services.AddResponseCompression();
        }

        // Middleware Hatt� Konfig�rasyonu
        private static void ConfigureMiddlewarePipeline(WebApplication app)
        {
            // Geli�tirme Ortam� Hata Y�netimi
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                // �retim Ortam� G�venlik Ayarlar�
                app.UseHsts();
                app.UseExceptionHandler("/SystemError");
            }

            // G�venlik ve Performans Middleware'leri
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseResponseCompression();
        }

        // Dinamik Rotalama Stratejisi
        private static void DefineRoutingStrategies(WebApplication app)
        {
            // Ana �� Ak�� Rotas�
            app.MapControllerRoute(
                name: "primaryWorkflow",
                pattern: "{controller=CustomerOrders}/{action=Index}/{id?}",
                constraints: new { id = @"\d+" }  // Sadece say�sal ID'ler
            );

            // Alternatif Rota Desenleri
            app.MapControllerRoute(
                name: "secondaryWorkflow",
                pattern: "api/{controller}/{action}/{token?}"
            );
        }
    }

    // Giri� Noktas� S�n�f�
    public static class DigitalPlatformEntryPoint
    {
        public static void Main(string[] args)
        {
            // Dijital Ekosistemi Ba�lat
            SmartApplicationBootstrapper.InitializeDigitalEcosystem(args);
        }
    }
}