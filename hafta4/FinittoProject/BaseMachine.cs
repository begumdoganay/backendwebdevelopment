using System;
using System.Xml.Linq;

namespace FinishExample
{
    // Smartphone sınıfı, BaseMachine sınıfından türetilmiştir
    public class Smartphone : BaseMachine
    {
        public int CameraMegapixels { get; set; } // Kameranın megapiksel değeri
        public bool Has5G { get; set; } // 5G desteği olup olmadığı

        public Smartphone(string serialNumber, string name, string description, string operatingSystem, int cameraMegapixels, bool has5G)
            : base(serialNumber, name, description, operatingSystem)
        {
            CameraMegapixels = cameraMegapixels;
            Has5G = has5G;
        }

        public override string GetProductName()
        {
            return $"{Name} (Smartphone)";
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Camera: {CameraMegapixels} MP - 5G Support: {(Has5G ? "Yes" : "No")}");
        }
    }

    // Tablet sınıfı, BaseMachine sınıfından türetilmiştir
    public class Tablet : BaseMachine
    {
        public bool SupportsStylus { get; set; } // Stylus desteği olup olmadığı
        public int ScreenSize { get; set; } // Ekran boyutu

        public Tablet(string serialNumber, string name, string description, string operatingSystem, int screenSize, bool supportsStylus)
            : base(serialNumber, name, description, operatingSystem)
        {
            ScreenSize = screenSize;
            SupportsStylus = supportsStylus;
        }

        public override string GetProductName()
        {
            return $"{Name} (Tablet)";
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Screen Size: {ScreenSize} inches - Stylus Support: {(SupportsStylus ? "Yes" : "No")}");
        }
    }

    // Smartwatch sınıfı, BaseMachine sınıfından türetilmiştir
    public class Smartwatch : BaseMachine
    {
        public bool IsWaterResistant { get; set; } // Su geçirmez olup olmadığı
        public int BatteryLifeDays { get; set; } // Batarya ömrü (gün)

        public Smartwatch(string serialNumber, string name, string description, string operatingSystem, int batteryLifeDays, bool isWaterResistant)
            : base(serialNumber, name, description, operatingSystem)
        {
            BatteryLifeDays = batteryLifeDays;
            IsWaterResistant = isWaterResistant;
        }

        public override string GetProductName()
        {
            return $"{Name} (Smartwatch)";
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Battery Life: {BatteryLifeDays} days - Water Resistant: {(IsWaterResistant ? "Yes" : "No")}");
        }
    }

    // Program sınıfı
    class Program
    {
        static void Main(string[] args)
        {
            // Smartphone nesnesi oluştur
            Smartphone smartphone = new Smartphone("SPH789", "Flagship Phone", "High-end smartphone with powerful camera.", "Android", 108, true);
            smartphone.PrintInfo(); // Smartphone bilgilerini yazdır

            Console.WriteLine(); // Yeni satır

            // Tablet nesnesi oluştur
            Tablet tablet = new Tablet("TAB123", "Pro Tablet", "Tablet with large screen and stylus support.", "iOS", 12, true);
            tablet.PrintInfo(); // Tablet bilgilerini yazdır

            Console.WriteLine(); // Yeni satır

            // Smartwatch nesnesi oluştur
            Smartwatch smartwatch = new Smartwatch("SWT456", "Fitness Watch", "Water-resistant fitness tracking smartwatch.", "WearOS", 7, true);
            smartwatch.PrintInfo(); // Smartwatch bilgilerini yazdır
        }
    }
}
