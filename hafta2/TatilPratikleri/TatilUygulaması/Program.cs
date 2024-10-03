using System;

class Program
{
    static void Main()
    {
        bool devamEtmekIstiyorMu = true;
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Seyahat Yardımcınıza Hoş Geldiniz!");
        Console.WriteLine("----------------------------------");

        while (devamEtmekIstiyorMu)
        {
            // Kullanıcının gitmek istediği yeri seçmesi
            string lokasyon = LokasyonSecimi();
            int lokasyonFiyati = LokasyonFiyatiniBul(lokasyon);

            // Kaç kişi tatil yapacağı
            int kisiSayisi = KacKisiTatilde();

            // Ulaşım tercihi
            int ulasimMaliyeti = UlasimTercihi(kisiSayisi);

            // Toplam fiyat hesaplama
            int toplamFiyat = ToplamFiyatHesapla(lokasyonFiyati, ulasimMaliyeti, kisiSayisi);

            // Tatil bilgilerini ekrana yazdırma
            TatilBilgileriniYazdir(lokasyon, kisiSayisi, toplamFiyat);

            // Başka tatil planlamak isteyip istemediğini sorma
            devamEtmekIstiyorMu = BaskaTatilPlanla();
        }

        Console.WriteLine("\nBizi tercih ettiğiniz için teşekkür ederiz. Unutmayın, tatil planı yaparken Seyahat Yardımcınız hep yanınızda!");
    }

    static string LokasyonSecimi()
    {
        string[] lokasyonlar = { "bodrum", "marmaris", "cesme" };
        string lokasyon = "";

        while (true)
        {
            Console.WriteLine("\n Lütfen tatil yapmak istediğiniz lokasyonu seçiniz:");
            Console.WriteLine("1 - Bodrum (Muhteşem plajlar ve gece hayatı!)");
            Console.WriteLine("2 - Marmaris (Doğal güzellikler ve eğlenceli aktiviteler!)");
            Console.WriteLine("3 - Çeşme (Sörf cenneti ve harika restoranlar!)");
            lokasyon = Console.ReadLine().Trim().ToLower();

            if (Array.Exists(lokasyonlar, l => l == lokasyon))
            {
                break;
            }
            else
            {
                Console.WriteLine("Maalesef bu lokasyonu bulamadık. Lütfen Bodrum, Marmaris veya Çeşme'den birini seçiniz.");
            }
        }

        return char.ToUpper(lokasyon[0]) + lokasyon.Substring(1); // Lokasyon adını büyük harfle başlatma adına. 
    }

    static int LokasyonFiyatiniBul(string lokasyon)
    {
        switch (lokasyon.ToLower())
        {
            case "bodrum":
                return 4000;
            case "marmaris":
                return 3000;
            case "cesme":
                return 5000;
            default:
                return 0; // Hata durumu için bir kez durdur. 
        }
    }

    static int KacKisiTatilde()
    {
        int kisiSayisi = 0;
        while (true)
        {
            Console.Write("Kaç kişi tatil planlıyorsunuz? ");
            if (int.TryParse(Console.ReadLine(), out kisiSayisi) && kisiSayisi > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Geçerli bir kişi sayısı giriniz (pozitif bir sayı olmalıdır).");
            }
        }
        return kisiSayisi;
    }

    static int UlasimTercihi(int kisiSayisi)
    {
        int ulasimUcreti = 0;

        while (true)
        {
            Console.WriteLine("\nNasıl bir ulaşım tercih ediyorsunuz?");
            Console.WriteLine("1 - Kara yolu (Kişi başı 1500 TL)");
            Console.WriteLine("2 - Hava yolu (Kişi başı 4000 TL)");
            Console.Write("Lütfen 1 veya 2 numaralı seçeneği giriniz: ");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                ulasimUcreti = 1500 * kisiSayisi;
                break;
            }
            else if (secim == "2")
            {
                ulasimUcreti = 4000 * kisiSayisi;
                break;
            }
            else
            {
                Console.WriteLine("Geçersiz bir seçenek girdiniz. Lütfen yalnızca 1 ya da 2'yi seçiniz.");
            }
        }

        return ulasimUcreti;
    }

    static int ToplamFiyatHesapla(int lokasyonFiyati, int ulasimFiyati, int kisiSayisi)
    {
        return (lokasyonFiyati * kisiSayisi) + ulasimFiyati;
    }

    static void TatilBilgileriniYazdir(string lokasyon, int kisiSayisi, int toplamFiyat)
    {
        Console.WriteLine($"\n Tatilinizle ilgili bilgiler:");
        Console.WriteLine($"- Lokasyon: {lokasyon}");
        Console.WriteLine($"- Kişi Sayısı: {kisiSayisi}");
        Console.WriteLine($"- Toplam Fiyat: {toplamFiyat} TL");
        Console.WriteLine($"- {lokasyon} tatilinizde güneşin ve denizin tadını çıkarabilirsiniz!");
    }

    static bool BaskaTatilPlanla()
    {
        Console.Write("\n Başka bir tatil planlamak ister misiniz? (Evet/Hayır): "); // son kısımda tekrarlamaması adına
        string cevap = Console.ReadLine().Trim().ToLower();

        return cevap == "evet";
    }
}
