using System;

namespace FinishExample
{
    // BaseMachine sınıfı, bilgisayar gibi makineler için temel özellikleri içeriyor. Yani aradığımızı burada bulabileceğiz. 
    public abstract class BaseMachine
    {
        public DateTime CreationDate { get; set; } // Makinenin oluşturulma tarihi
        public string SerialNumber { get; set; } // Seri numarası
        public string Name { get; set; } // Makine adı
        public string Description { get; set; } // Açıklama
        public string OperatingSystem { get; set; } // İşletim sistemi

        // Yapıcı metot (constructor): Temel bilgileri alıp ayarlıyoruz
        public BaseMachine(string serialNumber, string name, string description, string operatingSystem)
        {
            CreationDate = DateTime.Now; // Oluşturulma tarihi, nesne oluşturulduğunda atanmış hale geliyor. 
            SerialNumber = serialNumber;
            Name = name;
            Description = description;
            OperatingSystem = operatingSystem;
        }

        // Makine bilgilerini ekrana yazdırmak için temel metot budur. Kullanalımmmmm
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Ad: {Name} - Açıklama: {Description} - İşletim Sistemi: {OperatingSystem} - Seri Numarası: {SerialNumber} - Oluşturulma Tarihi: {CreationDate}");
        }

        // Ürünün adını döndüren soyut metot (türeyen sınıflarda implement edilecek)
        public abstract string GetProductName();
    }

    // Computer sınıfı, BaseMachine'den türetiliyor
    public class Computer : BaseMachine
    {
        private int _usbPorts; // USB port sayısını saklamak için özel alan
        private int _ramSize; // RAM miktarını saklamak için özel alan (GB cinsinden)

        // Yeni özellik: Bilgisayarın işlemci tipi
        public string ProcessorType { get; set; }

        // Yapıcı metot (constructor): Bilgisayar oluştururken USB port sayısı, RAM miktarı ve işlemci tipi gibi detayları belirliyoruz
        public Computer(string serialNumber, string name, string description, string operatingSystem, int usbCount, int ramSize, string processorType)
            : base(serialNumber, name, description, operatingSystem) // BaseMachine'deki temel özellikleri çağırıyoruz
        {
            UsbPorts = usbCount; // USB port sayısını ayarlıyoruz, aşağıda kontrol ediyoruz
            RamSize = ramSize; // RAM miktarını ayarlıyoruz
            ProcessorType = processorType; // İşlemci tipini ayarlıyoruz
        }

        // USB port sayısını kontrol eden özellik
        public int UsbPorts
        {
            get => _usbPorts; // Değer döndürme işlemi
            set
            {
                // Eğer port sayısı 2 veya 4 değilse, kullanıcıya tekrar deneme şansı veriyoruz
                while (value != 2 && value != 4)
                {
                    // Kullanıcıya samimi bir uyarı mesajı gösteriyoruz
                    Console.WriteLine("Hatalı USB port sayısı girdiniz! Lütfen 2 veya 4 girin:");

                    // Kullanıcıdan yeni giriş yapmasını istiyoruz ve sayıya çevirebiliyorsak tekrar kontrol ediyoruz
                    if (int.TryParse(Console.ReadLine(), out int newValue))
                    {
                        value = newValue; // Yeni değeri alıp döngüyü tekrarlıyoruz
                    }
                    else
                    {
                        // Kullanıcı sayı girmediğinde onları tekrar uyarıyoruz
                        Console.WriteLine("Geçersiz giriş! Sayı girmeniz gerekiyor.");
                    }
                }
                // Sonunda geçerli bir değeri ayarlıyoruz
                _usbPorts = value;
            }
        }

        // RAM miktarını kontrol eden özellik
        public int RamSize
        {
            get => _ramSize; // Değer döndürme işlemi
            set
            {
                // Eğer RAM miktarı çok düşükse, minimum 4 GB ayarlıyoruz ve kullanıcıya haber veriyoruz
                if (value < 4)
                {
                    Console.WriteLine("Çok düşük RAM miktarı! Minimum 4 GB RAM olması gerekiyor.");
                    _ramSize = 4; // Minimum RAM değeri ayarlanıyor
                }
                else
                {
                    _ramSize = value; // Geçerli bir değer atandı
                }
            }
        }

        // Bilgisayar bilgilerini ekrana yazdıran metot
        public override void PrintInfo()
        {
            // Bilgisayarın genel bilgilerini yazdırıyoruz
            Console.WriteLine($"Bilgisayar Adı: {Name} - Açıklama: {Description} - İşletim Sistemi: {OperatingSystem} - Seri Numarası: {SerialNumber}");
            // Ek özellikler (USB portları, RAM ve işlemci tipi) de ekranda gösteriliyor
            Console.WriteLine($"Oluşturulma Tarihi: {CreationDate} - USB Portları: {UsbPorts} - RAM: {RamSize} GB - İşlemci: {ProcessorType}");
        }

        // Bilgisayarın ürün adını döndüren metot
        public override string GetProductName()
        {
            // Kullanıcıya bilgisayar adını ve işlemci tipini döndürerek ekstra bilgi veriyoruz
            return $"Bilgisayarınız: {Name}, İşlemci: {ProcessorType}";
        }
    }

    // Program sınıfı, uygulamayı çalıştırdığımız yer
    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıya yeni bir bilgisayar oluşturma sürecini başlatıyoruz
            Console.WriteLine("Yeni bilgisayarınızı oluşturalım!");

            // Kullanıcıdan bilgisayara ait temel bilgileri alıyoruz
            Console.Write("Seri Numarası: ");
            string serialNumber = Console.ReadLine();

            Console.Write("Bilgisayar Adı: ");
            string name = Console.ReadLine();

            Console.Write("Açıklama: ");
            string description = Console.ReadLine();

            Console.Write("İşletim Sistemi: ");
            string operatingSystem = Console.ReadLine();

            // Kullanıcıdan USB port sayısını alıyoruz ve bir sayı olup olmadığını kontrol ediyoruz
            Console.Write("USB Port Sayısı (2 veya 4): ");
            int usbCount = int.Parse(Console.ReadLine());

            // RAM miktarını alıyoruz ve bir sayı olup olmadığını kontrol ediyoruz
            Console.Write("RAM Miktarı (GB): ");
            int ramSize = int.Parse(Console.ReadLine());

            // Kullanıcıdan işlemci tipini alıyoruz
            Console.Write("İşlemci Tipi: ");
            string processorType = Console.ReadLine();

            // Kullanıcıdan alınan bilgilerle yeni bilgisayar oluşturuyoruz
            Computer myComputer = new Computer(serialNumber, name, description, operatingSystem, usbCount, ramSize, processorType);

            // Bilgisayar bilgilerini yazdırıyoruz
            myComputer.PrintInfo();
        }
    }
}
