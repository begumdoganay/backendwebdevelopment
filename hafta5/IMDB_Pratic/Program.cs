using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDB_Pratic
{

    // Film sınıfı, buyrun efeniiiim her yol var burada KOLPACINO 1,2, RECEP IVEDIK TUM SERI 
    class Film
    {
        public string Isim { get; set; }
        public double ImdbPuani { get; set; }

        public Film(string isim, double imdbPuani)
        {
            Isim = isim;
            ImdbPuani = imdbPuani;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Film listesi, yani bizim süper gizli film arşivimiz 🕵️‍♂️
            List<Film> filmListesi = new List<Film>();

            while (true)
            {
                // Kullanıcıdan film adını sinsice öğreniyoruz 😏
                Console.Write("Hangi filmi ekleyelim? ");
                string filmAdi = Console.ReadLine();

                double imdbPuani;
                while (true)
                {
                    // IMDB puanını öğrenme zamanı! Bakalım film ne kadar geçer not alıyor? 🆒
                    Console.Write("Bu film kaç yıldız alır? (IMDB puanı yani, abartma): ");
                    if (double.TryParse(Console.ReadLine(), out imdbPuani))
                    {
                        break;
                    }
                    Console.WriteLine("Yok artık! Adam gibi bir sayı gir be!");
                }

                // Yeni film doğuyor! 🎬 Hoş geldin bebeğim!
                filmListesi.Add(new Film(filmAdi, imdbPuani));

                // Devam mı, yoksa mola mı?
                Console.Write("Başka? (E/H - Evet için E'ye bas, yoksa başka tuşa): ");
                if (Console.ReadLine().Trim().ToUpper() != "E")
                {
                    break;
                }
            }

            // Bütün filmleri dökelim ortaya! 🍿
            Console.WriteLine("\n1. İşte bizim film koleksiyonu:");
            ListeleyFilmler(filmListesi);

            // Orta karar filmler (ne çöp, ne elmas yani)
            Console.WriteLine("\n2. Fena sayılmaz dediklerimiz (IMDB 4-9 arası):");
            ListeleyFilmler(filmListesi.Where(f => f.ImdbPuani >= 4 && f.ImdbPuani <= 9).ToList());

            // A'dan başlayanlar (çünkü neden olmasın?)
            Console.WriteLine("\n3. A'dan başlayan filmler (büyük küçük harf farketmez, cool çocuklarız biz 😎):");
            ListeleyFilmler(filmListesi.Where(f => f.Isim.StartsWith("A") || f.Isim.StartsWith("a")).ToList());
        }

        // Filmleri ekrana fırlatıyoruz! 💥
        static void ListeleyFilmler(List<Film> filmler)
        {
            foreach (var film in filmler)
            {
                Console.WriteLine($"{film.Isim} - Yıldız Sayısı: {film.ImdbPuani} ⭐");
            }
        }
    }


}
