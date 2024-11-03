using System;
using System.Collections.Generic;
using System.Linq;

namespace Patikaflix
{
    // 📺 Dizi sınıfımız - Her dizinin kimlik bilgilerini tutacak
    public class TVSeries
    {
        public string Name { get; set; }         // Dizimizin adı
        public int Year { get; set; }            // Yapım yılı (eski mi yeni mi?)
        public string Genre { get; set; }        // Türü (komedi mi dram mı?)
        public string StartYear { get; set; }    // Başlangıç yılı
        public string Director { get; set; }     // Yönetmenimiz kim?
        public string Platform { get; set; }     // Hangi kanalda yayınlanıyor
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 🎬 Dizilerimizi hazırlayalım! İşte en sevilen Türk dizileri...
            var diziler = new List<TVSeries>
            {
                new TVSeries { Name = "Avrupa Yakası", Year = 2004, Genre = "Komedi", StartYear = "2004", Director = "Yüksel Aksu", Platform = "Kanal D" },
                // Sütçüoğlu muhallebicisinden AVRUPAAA YAKASI 😄
                new TVSeries { Name = "Yalan Dünya", Year = 2012, Genre = "Komedi", StartYear = "2012", Director = "Gülseren Buda Başkaya", Platform = "Fox TV" },
                // Sosyetenin en komik hali!
                new TVSeries { Name = "Jet Sosyete", Year = 2018, Genre = "Komedi", StartYear = "2018", Director = "Gülseren Buda Başkaya", Platform = "TV8" },
                // Dadııııı! 
                new TVSeries { Name = "Dadı", Year = 2006, Genre = "Komedi", StartYear = "2006", Director = "Yusuf Pirhasan", Platform = "Kanal D" },
                // Ah şu baldızlar...
                new TVSeries { Name = "Belalı Baldız", Year = 2007, Genre = "Komedi", StartYear = "2007", Director = "Yüksel Aksu", Platform = "Kanal D" }
            };

            Console.WriteLine("🎭 Patikaflix'e Hoş Geldiniz! 🎭");
            Console.WriteLine("===============================");

            // Hadi biraz LINQ eğlencesi yapalım! 🎮

            Console.WriteLine("\n🎪 Komedi Şov Başlıyor!");
            var komediDizileri = diziler
                .Where(dizi => dizi.Genre.Contains("Komedi"))
                .OrderBy(dizi => dizi.Name);

            foreach (var dizi in komediDizileri)
            {
                Console.WriteLine($"🎯 {dizi.Name} - Yönetmen: {dizi.Director}");
            }

            // 🎨 Yönetmenlerimizin istatistikleri
            Console.WriteLine("\n🎬 Yönetmenlerimizin Dizi Sayıları");
            var yonetmenler = diziler
                .GroupBy(d => d.Director)
                .Select(g => new {
                    Yonetmen = g.Key,
                    DiziSayisi = g.Count(),
                    Diziler = string.Join(", ", g.Select(d => d.Name))
                });

            foreach (var yonetmen in yonetmenler)
            {
                Console.WriteLine($"👉 {yonetmen.Yonetmen}: {yonetmen.DiziSayisi} dizi yönetmiş!");
                Console.WriteLine($"   💫 Dizileri: {yonetmen.Diziler}");
            }

            // 📊 Platform analizi
            Console.WriteLine("\n📺 Hangi Platform Daha Çok Dizi Yapmış?");
            var platformAnalizi = diziler
                .GroupBy(d => d.Platform)
                .Select(g => new { Platform = g.Key, DiziSayisi = g.Count() })
                .OrderByDescending(x => x.DiziSayisi);

            foreach (var platform in platformAnalizi)
            {
                var emoji = platform.Platform == "Kanal D" ? "🥇" :
                           platform.Platform == "Fox TV" ? "🦊" : "📺";
                Console.WriteLine($"{emoji} {platform.Platform}: {platform.DiziSayisi} dizi");
            }
        }

        // 🆕 Yeni dizi eklemek için kullanacağımız metot
        public static void YeniDiziEkle(List<TVSeries> diziler, TVSeries yeniDizi)
        {
            diziler.Add(yeniDizi);
            Console.WriteLine($"🎉 Yeni dizi eklendi: {yeniDizi.Name}");
        }

        // 🔍 Dizi arama motoru
        public static void DiziAra(List<TVSeries> diziler, string arananKelime)
        {
            var bulunanDiziler = diziler
                .Where(d => d.Name.Contains(arananKelime, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (bulunanDiziler.Any())
            {
                Console.WriteLine($"🔍 '{arananKelime}' için {bulunanDiziler.Count} dizi bulundu:");
                foreach (var dizi in bulunanDiziler)
                {
                    Console.WriteLine($"✨ {dizi.Name} ({dizi.Year}) - {dizi.Genre}");
                }
            }
            else
            {
                Console.WriteLine($"😢 Ups! '{arananKelime}' ile ilgili dizi bulamadık.");
            }
        }

        // 📅 En verimli yılı bulalım
        public static void EnVerimliYil(List<TVSeries> diziler)
        {
            var enVerimliYil = diziler
                .GroupBy(d => d.Year)
                .OrderByDescending(g => g.Count())
                .First();

            Console.WriteLine($"🏆 En verimli yıl: {enVerimliYil.Key}");
            Console.WriteLine("📺 O yılın dizileri:");
            foreach (var dizi in enVerimliYil)
            {
                Console.WriteLine($"   ⭐ {dizi.Name}");
            }
        }
    }
}