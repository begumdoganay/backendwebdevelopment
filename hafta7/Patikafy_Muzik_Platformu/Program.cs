using System;
using System.Collections.Generic;
using System.Linq;

class Artist
    {
        public string Name { get; set; }
        public string MusicType { get; set; }
        public int ReleaseYear { get; set; }
        public int AlbumSales { get; set; }

        public override string ToString()
        {
            return $"{Name} - {MusicType} ({ReleaseYear}) - {AlbumSales:N0} satış";
        }
    }

    class Program
    {
        static void Main()
        {
            // Create our artist database
            var artists = new List<Artist>
        {
            new Artist { Name = "Ajda Pekkan", MusicType = "Pop", ReleaseYear = 1968, AlbumSales = 20000000 },
            new Artist { Name = "Sezen Aksu", MusicType = "Türk Halk Müziği / Pop", ReleaseYear = 1971, AlbumSales = 10000000 },
            new Artist { Name = "Funda Arar", MusicType = "Pop", ReleaseYear = 1999, AlbumSales = 3000000 },
            new Artist { Name = "Sertab Erener", MusicType = "Pop", ReleaseYear = 1994, AlbumSales = 5000000 },
            new Artist { Name = "Sıla", MusicType = "Pop", ReleaseYear = 2009, AlbumSales = 3000000 },
            new Artist { Name = "Serdar Ortaç", MusicType = "Pop", ReleaseYear = 1994, AlbumSales = 10000000 },
            new Artist { Name = "Tarkan", MusicType = "Pop", ReleaseYear = 1992, AlbumSales = 40000000 },
            new Artist { Name = "Hande Yener", MusicType = "Pop", ReleaseYear = 1999, AlbumSales = 7000000 },
            new Artist { Name = "Hadise", MusicType = "Pop", ReleaseYear = 2005, AlbumSales = 5000000 },
            new Artist { Name = "Gülben Ergen", MusicType = "Pop / Türk Halk Müziği", ReleaseYear = 1997, AlbumSales = 10000000 },
            new Artist { Name = "Neşet Ertaş", MusicType = "Türk Halk Müziği / Türk Sanat Müziği", ReleaseYear = 1960, AlbumSales = 2000000 }
        };

            // 1. Artists whose names start with 'S'
            Console.WriteLine("🎤 Adı 'S' ile başlayan şarkıcılar:");
            var sArtists = artists.Where(a => a.Name.StartsWith("S"));
            foreach (var artist in sArtists)
            {
                Console.WriteLine(artist);
            }
            Console.WriteLine();

            // 2. Artists with album sales over 10 million
            Console.WriteLine("💿 Albüm satışları 10 milyon'un üzerinde olan şarkıcılar:");
            var highSales = artists.Where(a => a.AlbumSales >= 10000000);
            foreach (var artist in highSales)
            {
                Console.WriteLine(artist);
            }
            Console.WriteLine();

            // 3. Pre-2000 pop artists, sorted alphabetically
            Console.WriteLine("🎵 2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar (alfabetik):");
            var pre2000Pop = artists
                .Where(a => a.ReleaseYear < 2000 && a.MusicType.Contains("Pop"))
                .OrderBy(a => a.Name);
            foreach (var artist in pre2000Pop)
            {
                Console.WriteLine(artist);
            }
            Console.WriteLine();

            // 4. Artist with highest album sales
            Console.WriteLine("👑 En çok albüm satan şarkıcı:");
            var topSeller = artists.OrderByDescending(a => a.AlbumSales).First();
            Console.WriteLine(topSeller);
            Console.WriteLine();

            // 5. Newest and oldest artists
            Console.WriteLine("📅 En yeni ve en eski çıkış yapan şarkıcılar:");
            var newest = artists.OrderByDescending(a => a.ReleaseYear).First();
            var oldest = artists.OrderBy(a => a.ReleaseYear).First();
            Console.WriteLine($"En yeni: {newest}");
            Console.WriteLine($"En eski: {oldest}");
        }
    }


