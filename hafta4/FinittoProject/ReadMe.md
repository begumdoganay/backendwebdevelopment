💣 Hafta 4 - Kapanış Projesi
Bu proje, bir teknoloji mağazasında Telefon ve Bilgisayar kayıtlarını almak için geliştirilmiş bir C# konsol uygulamasıdır. Aşağıdaki C# konularını öğrenmek ve pekiştirmek amacıyla tasarlanmıştır:

Inheritance (Miras Alma): Temel sınıf olan BaseMakine'den miras alan Telefon ve Bilgisayar sınıfları.
Encapsulation (Kapsülleme): Usb giriş sayısının doğrulanması gibi veri gizleme.
Polymorphism (Çok Biçimlilik): Ürün bilgilerini yazdıran ve farklı sınıflarda ezilen (override) metotlar.
Abstraction (Soyutlama): Ürün adı getiren soyut metot ile farklı sınıfların kendine özgü özelliklerini göstermek.
📚 Proje Hakkında
Bu proje, telefon ve bilgisayar üretim sürecini konsol ekranında simüle etmek için yapılmıştır. Kullanıcıdan alınan bilgilerle her iki tür cihaz için nesne üretilir ve bilgileri ekrana yazdırılır.

🛠️ Kullanılan Konular
Sınıflar arası miras (Inheritance)
Kapsülleme (Encapsulation)
Çok biçimlilik (Polymorphism)
Soyut sınıflar ve metotlar (Abstraction)
📝 Projenin İstenilen Görevleri
1. Sınıf Yapısı
📱 Telefon
Üretim Tarihi: Otomatik atanır.
Seri Numarası, Ad, Açıklama, İşletim Sistemi: Kullanıcıdan alınır.
TR Lisanslı olup olmama: Kullanıcıdan alınır.
💻 Bilgisayar
Üretim Tarihi: Otomatik atanır.
Seri Numarası, Ad, Açıklama, İşletim Sistemi: Kullanıcıdan alınır.
Usb Giriş Sayısı: 2 veya 4 olabilir, aksi durumda uyarı verilir ve -1 atanır.
Bluetooth olup olmama: Kullanıcıdan alınır.
🏗️ BaseMakine (Temel Sınıf)
BaseMakine sınıfı, Üretim Tarihi, Seri Numarası, Ad, Açıklama, İşletim Sistemi gibi ortak özelliklere sahiptir.
Bir BilgileriYazdir() metodu içerir ve bu metot her sınıf tarafından ezilerek (override) kendi ek özelliklerini ekler.
Ayrıca, UrunAdiGetir() adlı soyut bir metot bulunur. Bu metot, Telefon ve Bilgisayar sınıflarında ürün adlarını özelleştirir.
🚀 Program Akışı
Kullanıcıya, telefon üretmek için 1, bilgisayar üretmek için 2 tuşlarına basmasını söyler.
Seçilen cihaza ait bilgileri kullanıcıdan alır:
Telefon için: Seri numarası, ad, açıklama, işletim sistemi ve TR lisanslı olup olmadığı.
Bilgisayar için: Seri numarası, ad, açıklama, işletim sistemi, usb giriş sayısı ve bluetooth olup olmama durumu.
Ürün başarıyla oluşturulduğunda, bilgilerini ekrana yazdırır.
Kullanıcıya başka bir ürün üretmek isteyip istemediğini sorar.
Kullanıcı "evet" derse, program başa döner. "Hayır" derse, uygulama "İyi günler!" mesajı ile sonlandırılır.
💻 Kod Yapısı
BaseMakine Sınıfı
Bu sınıf, telefon ve bilgisayar için ortak olan özellikleri içerir. Her iki sınıf da bu sınıftan miras alır:

csharp
Copy code
public abstract class BaseMakine
{
    public DateTime UretimTarihi { get; set; }
    public string SeriNumarasi { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public string IsletimSistemi { get; set; }

    public BaseMakine(string seriNumarasi, string ad, string aciklama, string isletimSistemi)
    {
        UretimTarihi = DateTime.Now;
        SeriNumarasi = seriNumarasi;
        Ad = ad;
        Aciklama = aciklama;
        IsletimSistemi = isletimSistemi;
    }

    public virtual void BilgileriYazdir()
    {
        Console.WriteLine($"Ad: {Ad}, Seri Numarası: {SeriNumarasi}, İşletim Sistemi: {IsletimSistemi}, Üretim Tarihi: {UretimTarihi}");
    }

    public abstract string UrunAdiGetir();
}
Telefon ve Bilgisayar Sınıfları
Her iki sınıf da BaseMakine sınıfından miras alır ve BilgileriYazdir() ile UrunAdiGetir() metodunu kendine özgü şekilde uygular.

Telefon Sınıfı
csharp
Copy code
public class Telefon : BaseMakine
{
    public bool TRLisansli { get; set; }

    public Telefon(string seriNumarasi, string ad, string aciklama, string isletimSistemi, bool trLisansli)
        : base(seriNumarasi, ad, aciklama, isletimSistemi)
    {
        TRLisansli = trLisansli;
    }

    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir();
        Console.WriteLine($"TR Lisanslı: {TRLisansli}");
    }

    public override string UrunAdiGetir()
    {
        return $"Telefonunuzun adı ---> {Ad}";
    }
}
Bilgisayar Sınıfı
csharp
Copy code
public class Bilgisayar : BaseMakine
{
    private int _usbGirisSayisi;
    public bool BluetoothVarMi { get; set; }

    public Bilgisayar(string seriNumarasi, string ad, string aciklama, string isletimSistemi, int usbGirisSayisi, bool bluetoothVarMi)
        : base(seriNumarasi, ad, aciklama, isletimSistemi)
    {
        UsbGirisSayisi = usbGirisSayisi;
        BluetoothVarMi = bluetoothVarMi;
    }

    public int UsbGirisSayisi
    {
        get => _usbGirisSayisi;
        set
        {
            if (value == 2 || value == 4)
            {
                _usbGirisSayisi = value;
            }
            else
            {
                Console.WriteLine("Geçersiz USB Giriş Sayısı. 2 veya 4 olmalı.");
                _usbGirisSayisi = -1;
            }
        }
    }

    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir();
        Console.WriteLine($"USB Giriş Sayısı: {UsbGirisSayisi}, Bluetooth: {BluetoothVarMi}");
    }

    public override string UrunAdiGetir()
    {
        return $"Bilgisayarınızın adı ---> {Ad}";
    }
}
📊 Örnek Çıktılar
Telefon üretimi:

yaml
Copy code
Telefon Adı: iPhone
Seri Numarası: ABC123
İşletim Sistemi: iOS
Üretim Tarihi: 10/17/2024
TR Lisanslı: Evet
Bilgisayar üretimi:

yaml
Copy code
Bilgisayar Adı: Lenovo
Seri Numarası: XYZ456
İşletim Sistemi: Windows
Üretim Tarihi: 10/17/2024
USB Giriş Sayısı: 2
Bluetooth: Var
🔄 Tekrar Ürün Üretme
Programda, kullanıcıya tekrar başka bir ürün üretmek isteyip istemediği sorulur. "Evet" yanıtı verildiğinde döngü başa döner, "Hayır" denildiğinde ise program sonlandırılır.