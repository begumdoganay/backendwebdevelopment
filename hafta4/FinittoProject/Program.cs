using System;

public abstract class BaseMakine
{
    public DateTime UretimTarihi { get; private set; }
    public string SeriNumarasi { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public string IsletimSistemi { get; set; }

    public BaseMakine()
    {
        UretimTarihi = DateTime.Now;
    }

    public virtual void BilgileriYazdir()
    {
        Console.WriteLine($"\nÜrün Bilgileri:");
        Console.WriteLine($"Üretim Tarihi: {UretimTarihi}");
        Console.WriteLine($"Seri Numarası: {SeriNumarasi}");
        Console.WriteLine($"Ad: {Ad}");
        Console.WriteLine($"Açıklama: {Aciklama}");
        Console.WriteLine($"İşletim Sistemi: {IsletimSistemi}");
    }

    public abstract void UrunAdiGetir();
}

public class Telefon : BaseMakine
{
    public bool TrLisansli { get; set; }

    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir();
        Console.WriteLine($"TR Lisanslı: {(TrLisansli ? "Evet" : "Hayır")}");
    }

    public override void UrunAdiGetir()
    {
        Console.WriteLine($"Telefonunuzun adı ---> {Ad}");
    }
}

public class Bilgisayar : BaseMakine
{
    private int _usbGirisSayisi;
    public bool BluetoothVarMi { get; set; }

    public int UsbGirisSayisi
    {
        get { return _usbGirisSayisi; }
        set
        {
            if (value == 2 || value == 4)
            {
                _usbGirisSayisi = value;
            }
            else
            {
                Console.WriteLine("Uyarı: USB giriş sayısı sadece 2 veya 4 olabilir. -1 değeri atandı.");
                _usbGirisSayisi = -1;
            }
        }
    }

    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir();
        Console.WriteLine($"USB Giriş Sayısı: {UsbGirisSayisi}");
        Console.WriteLine($"Bluetooth: {(BluetoothVarMi ? "Var" : "Yok")}");
    }

    public override void UrunAdiGetir()
    {
        Console.WriteLine($"Bilgisayarınızın adı ---> {Ad}");
    }
}

public class Program
{
    public static void Main()
    {
        bool devamEt = true;

        while (devamEt)
        {
            Console.WriteLine("\nTelefon üretmek için 1'e, Bilgisayar üretmek için 2'ye basınız:");
            string secim = Console.ReadLine();

            BaseMakine urun = null;

            if (secim == "1")
            {
                urun = YeniTelefonUret();
            }
            else if (secim == "2")
            {
                urun = YeniBilgisayarUret();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
                continue;
            }

            Console.WriteLine("\nÜrün başarıyla üretildi!");
            urun.BilgileriYazdir();
            urun.UrunAdiGetir();

            Console.WriteLine("\nBaşka bir ürün üretmek ister misiniz? (E/H)");
            devamEt = Console.ReadLine().ToUpper() == "E";
        }

        Console.WriteLine("İyi günler dileriz!");
    }

    private static Telefon YeniTelefonUret()
    {
        Telefon telefon = new Telefon();

        Console.WriteLine("Telefon bilgilerini giriniz:");
        Console.Write("Seri Numarası: ");
        telefon.SeriNumarasi = Console.ReadLine();

        Console.Write("Ad: ");
        telefon.Ad = Console.ReadLine();

        Console.Write("Açıklama: ");
        telefon.Aciklama = Console.ReadLine();

        Console.Write("İşletim Sistemi: ");
        telefon.IsletimSistemi = Console.ReadLine();

        Console.Write("TR Lisanslı mı? (E/H): ");
        telefon.TrLisansli = Console.ReadLine().ToUpper() == "E";

        return telefon;
    }

    private static Bilgisayar YeniBilgisayarUret()
    {
        Bilgisayar bilgisayar = new Bilgisayar();

        Console.WriteLine("Bilgisayar bilgilerini giriniz:");
        Console.Write("Seri Numarası: ");
        bilgisayar.SeriNumarasi = Console.ReadLine();

        Console.Write("Ad: ");
        bilgisayar.Ad = Console.ReadLine();

        Console.Write("Açıklama: ");
        bilgisayar.Aciklama = Console.ReadLine();

        Console.Write("İşletim Sistemi: ");
        bilgisayar.IsletimSistemi = Console.ReadLine();

        Console.Write("USB Giriş Sayısı (2 veya 4): ");
        bilgisayar.UsbGirisSayisi = int.Parse(Console.ReadLine());

        Console.Write("Bluetooth var mı? (E/H): ");
        bilgisayar.BluetoothVarMi = Console.ReadLine().ToUpper() == "E";

        return bilgisayar;
    }
}