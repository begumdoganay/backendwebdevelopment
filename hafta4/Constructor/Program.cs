using System;
using System.Collections.Generic;

public class Bebek
{
    public DateTime DogumTarihi { get; private set; }
    public string Ad { get; set; }
    public string Soyad { get; set; }
    private List<string> Sevdikleri { get; set; } = new List<string>();
    private Random rnd = new Random();

    // Default Constructor
    public Bebek()
    {
        BebekDogdu();
    }

    // Alternatif Constructor
    public Bebek(string ad, string soyad)
    {
        Ad = ad;
        Soyad = soyad;
        BebekDogdu();
    }

    private void BebekDogdu()
    {
        DogumTarihi = DateTime.Now;
        Console.WriteLine($"🍼👶 Ingaaaa! Yeni bir bebek dünyaya geldi: {DogumTarihi}");
    }

    public void SevdigiBirSeyEkle(string sevdigi)
    {
        Sevdikleri.Add(sevdigi);
        Console.WriteLine($"{Ad} artık {sevdigi}'yi çok seviyor! 😍");
    }

    public string RasgeleAgla()
    {
        string[] aglamalar = { "Üüüüü 😢", "Waaaah 😭", "Hıçk hıçk 😪", "Mııııı 🥺" };
        return aglamalar[rnd.Next(aglamalar.Length)];
    }

    public override string ToString()
    {
        string sevdikleriStr = Sevdikleri.Count > 0 ? string.Join(", ", Sevdikleri) : "Henüz bir şey sevmiyor";
        return $"👶 {Ad} {Soyad}\n" +
               $"🎂 Doğum Tarihi: {DogumTarihi}\n" +
               $"❤️ Sevdikleri: {sevdikleriStr}\n" +
               $"🔊 Şu an: {RasgeleAgla()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("🌟 Bebek 1 (Default Constructor):");
        Bebek bebek1 = new Bebek();
        bebek1.Ad = "Ayşe";
        bebek1.Soyad = "Minik";
        bebek1.SevdigiBirSeyEkle("Çıngırak");
        bebek1.SevdigiBirSeyEkle("Oyuncak ayı");
        Console.WriteLine(bebek1);

        Console.WriteLine("\n🌟 Bebek 2 (Alternatif Constructor):");
        Bebek bebek2 = new Bebek("Mehmet", "Ufaklık");
        bebek2.SevdigiBirSeyEkle("Emzik");
        Console.WriteLine(bebek2);
    }
}
