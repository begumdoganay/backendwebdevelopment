using FinishExample;
using System;
using System.Xml.Linq;

namespace FinittoProject
{
    // Phone sınıfı, BaseMachine sınıfından türetiliyor
    public class Phone : BaseMachine
    {
        // Yeni özellikler: Ekran boyutu, pil kapasitesi ve kamera çözünürlüğü
        public double ScreenSize { get; set; } // İnç cinsinden
        public int BatteryCapacity { get; set; } // mAh cinsinden
        public int CameraResolution { get; set; } // Megapiksel cinsinden

        // Telefon oluştururken bu özellikleri belirliyoruz
        public Phone(string serialNumber, string name, string description, string operatingSystem, double screenSize, int batteryCapacity, int cameraResolution)
            : base(serialNumber, name, description, operatingSystem)
        {
            ScreenSize = screenSize; // Ekran boyutu ayarlanıyor
            BatteryCapacity = batteryCapacity; // Pil kapasitesi ayarlanıyor
            CameraResolution = cameraResolution; // Kamera çözünürlüğü ayarlanıyor
        }

        // Telefon bilgilerini ekrana yazdıran metot
        public override void PrintInfo()
        {
            Console.WriteLine($"Telefon Adı: {Name} - Açıklama: {Description} - İşletim Sistemi: {OperatingSystem} - Seri Numarası: {SerialNumber}");
            Console.WriteLine($"Oluşturulma Tarihi: {CreationDate} - Ekran Boyutu: {ScreenSize}\" - Pil Kapasitesi: {BatteryCapacity} mAh - Kamera: {CameraResolution} MP");
        }

        // Ürünün adını döndüren metot
        public override string GetProductName()
        {
            return $"Telefonunuz: {Name}, Kamera: {CameraResolution} MP";
        }
    }

    // Program sınıfı, uygulamayı çalıştırdığımız yer
    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıya yeni bir telefon oluşturma sürecini başlatıyoruz
            Console.WriteLine("Yeni telefonunuzu oluşturalım!");

            // Kullanıcıdan temel bilgileri alıyoruz
            Console.Write("Seri Numarası: ");
            string serialNumber = Console.ReadLine();

            Console.Write("Telefon Adı: ");
            string name = Console.ReadLine();

            Console.Write("Açıklama: ");
            string description = Console.ReadLine();

            Console.Write("İşletim Sistemi: ");
            string operatingSystem = Console.ReadLine();

            // Ekran boyutunu alırken hatalı giriş yapılırsa kontrol ekliyoruz
            double screenSize;
            while (true)
            {
                Console.Write("Ekran Boyutu (inç): ");
                if (double.TryParse(Console.ReadLine(), out screenSize))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Geçerli bir sayı girin (örnek: 6.5).");
                }
            }

            // Pil kapasitesini alırken hatalı giriş yapılırsa kontrol ekliyoruz
            int batteryCapacity;
            while (true)
            {
                Console.Write("Pil Kapasitesi (mAh): ");
                if (int.TryParse(Console.ReadLine(), out batteryCapacity))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Geçerli bir tam sayı girin (örnek: 4000).");
                }
            }

            // Kamera çözünürlüğünü alırken hatalı giriş yapılırsa kontrol ekliyoruz
            int cameraResolution;
            while (true)
            {
                Console.Write("Kamera Çözünürlüğü (MP): ");
                if (int.TryParse(Console.ReadLine(), out cameraResolution))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Geçerli bir tam sayı girin (örnek: 12).");
                }
            }

            // Alınan bilgilerle yeni telefon oluşturuyoruz
            Phone myPhone = new Phone(serialNumber, name, description, operatingSystem, screenSize, batteryCapacity, cameraResolution);

            // Telefon bilgilerini yazdırıyoruz
            myPhone.PrintInfo();
        }
    }
}
