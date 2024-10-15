using System;

public class Kitap
{
    public string Ad { get; set; }
    public string YazarAdi { get; set; }
    public string YazarSoyadi { get; set; }
    public int SayfaSayisi { get; set; }
    public string Yayinevi { get; set; }
    public DateTime KayitTarihi { get; private set; }

    // Default constructor
    public Kitap()
    {
        KayitTarihi = DateTime.Now;
        Console.WriteLine($"Yeni bir kitap kaydedildi! Kayıt tarihi: {KayitTarihi}");
    }

    // Parametreli constructor
    public Kitap(string ad, string yazarAdi, string yazarSoyadi, int sayfaSayisi, string yayinevi)
    {
        Ad = ad;
        YazarAdi = yazarAdi;
        YazarSoyadi = yazarSoyadi;
        SayfaSayisi = sayfaSayisi;
        Yayinevi = yayinevi;
        KayitTarihi = DateTime.Now;
        Console.WriteLine($"Yeni bir kitap kaydedildi! Kayıt tarihi: {KayitTarihi}");
    }

    public override string ToString()
    {
        return $"📚 {Ad}\n" +
               $"✍️ Yazar: {YazarAdi} {YazarSoyadi}\n" +
               $"📄 Sayfa Sayısı: {SayfaSayisi}\n" +
               $"🏢 Yayınevi: {Yayinevi}\n" +
               $"📅 Kayıt Tarihi: {KayitTarihi}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("📚 Patika Kütüphanesi'ne Hoş Geldiniz! 📚");

        Kitap adiAylin = new Kitap("Adı Aylin", "Ayşe", "Kulin", 398, "Remzi Kitabevi");
        Console.WriteLine(adiAylin);

        Console.WriteLine("\nHadi bir kitap daha ekleyelim, ama bu sefer bilgileri sonradan girelim:");
        Kitap yeniKitap = new Kitap();
        yeniKitap.Ad = "Tutunamayanlar";
        yeniKitap.YazarAdi = "Oğuz";
        yeniKitap.YazarSoyadi = "Atay";
        yeniKitap.SayfaSayisi = 724;
        yeniKitap.Yayinevi = "İletişim Yayınları";
        Console.WriteLine(yeniKitap);
    }
}