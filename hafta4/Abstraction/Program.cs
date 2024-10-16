using System;

// Soyut (abstract) Calisan sınıfı
public abstract class Calisan
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string Departman { get; set; }

    // Soyut (abstract) Gorev metodu
    public abstract void Gorev();

    // Kurucu metod
    public Calisan(string ad, string soyad, string departman)
    {
        Ad = ad;
        Soyad = soyad;
        Departman = departman;
    }
}

// ProjeYoneticisi sınıfı, Calisan sınıfından türetilmiştir
public class ProjeYoneticisi : Calisan
{
    public ProjeYoneticisi(string ad, string soyad) : base(ad, soyad, "Proje Yönetimi")
    {
    }

    // Gorev metodunun uygulanması
    public override void Gorev()
    {
        Console.WriteLine("Proje yöneticisi olarak çalışıyorum.");
    }
}

// YazilimGelistirici sınıfı, Calisan sınıfından türetilmiştir
public class YazilimGelistirici : Calisan
{
    public YazilimGelistirici(string ad, string soyad) : base(ad, soyad, "Yazılım Geliştirme")
    {
    }

    // Gorev metodunun uygulanması
    public override void Gorev()
    {
        Console.WriteLine("Yazılım geliştirici olarak çalışıyorum.");
    }
}

// SatisTemsilcisi sınıfı, Calisan sınıfından türetilmiştir
public class SatisTemsilcisi : Calisan
{
    public SatisTemsilcisi(string ad, string soyad) : base(ad, soyad, "Satış")
    {
    }

    // Gorev metodunun uygulanması
    public override void Gorev()
    {
        Console.WriteLine("Satış temsilcisi olarak çalışıyorum.");
    }
}

// Program sınıfı
class Program
{
    static void Main(string[] args)
    {
        // Çalışanların oluşturulması
        Calisan projeYoneticisi = new ProjeYoneticisi("Hasan", "Çıldırmış");
        Calisan yazilimci = new YazilimGelistirici("Ayşe", "Kod");
        Calisan satisci = new SatisTemsilcisi("Mehmet", "Satır");

        // Görevlerin çağrılması
        Console.WriteLine($"{projeYoneticisi.Ad} {projeYoneticisi.Soyad}:");
        projeYoneticisi.Gorev();

        Console.WriteLine($"\n{yazilimci.Ad} {yazilimci.Soyad}:");
        yazilimci.Gorev();

        Console.WriteLine($"\n{satisci.Ad} {satisci.Soyad}:");
        satisci.Gorev();
    }
}
