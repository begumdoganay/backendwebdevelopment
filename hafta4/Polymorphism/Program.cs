using System;
using System.Collections.Generic;

namespace PolymorphismExample
{
    // Tüm şekiller için soyut temel sınıf
    // Soyut sınıf, temel özellikleri ve metotları belirler. Şeklin alanını hesaplama ve
    // çizim işlemi her şekil için farklı olacağı için bunları abstract yapıyoruz.
    public abstract class Shape
    {
        public abstract double CalculateArea(); // Alan hesaplama metodu
        public abstract void Draw(); // Şekli çizme metodu
    }

    // Daire sınıfı (Circle)
    // Shape sınıfından miras alıyor ve daireye özel alan hesaplama ve çizim işlemleri yapılıyor.
    public class Circle : Shape
    {
        public double Radius { get; set; } // Dairenin yarıçapı

        // Yapıcı (constructor), dairenin yarıçapını alır.
        public Circle(double radius)
        {
            Radius = radius;
        }

        // Alan hesaplama: π * r^2 formülü ile hesaplanır.
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        // Çizim işlemi (konsola yazdırma)
        public override void Draw()
        {
            Console.WriteLine($"Drawing a circle with radius {Radius}");
        }
    }

    // Dikdörtgen sınıfı (Rectangle)
    // Shape sınıfından miras alıyor ve dikdörtgene özel alan hesaplama ve çizim işlemleri yapılıyor.
    public class Rectangle : Shape
    {
        public double Width { get; set; } // Dikdörtgenin genişliği
        public double Height { get; set; } // Dikdörtgenin yüksekliği

        // Yapıcı (constructor), dikdörtgenin genişlik ve yüksekliğini alır.
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        // Alan hesaplama: genişlik * yükseklik formülü ile hesaplanır.
        public override double CalculateArea()
        {
            return Width * Height;
        }

        // Çizim işlemi (konsola yazdırma)
        public override void Draw()
        {
            Console.WriteLine($"Drawing a rectangle with width {Width} and height {Height}");
        }
    }

    // Üçgen sınıfı (Triangle)
    // Shape sınıfından miras alıyor ve üçgene özel alan hesaplama ve çizim işlemleri yapılıyor.
    public class Triangle : Shape
    {
        public double Base { get; set; } // Üçgenin tabanı
        public double Height { get; set; } // Üçgenin yüksekliği

        // Yapıcı (constructor), üçgenin taban ve yüksekliğini alır.
        public Triangle(double @base, double height) // @base: 'base' anahtar kelimesiyle çakışmayı önlemek için
        {
            Base = @base;
            Height = height;
        }

        // Alan hesaplama: (0.5 * taban * yükseklik) formülü ile hesaplanır.
        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }

        // Çizim işlemi (konsola yazdırma)
        public override void Draw()
        {
            Console.WriteLine($"Drawing a triangle with base {Base} and height {Height}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Şekilleri tutmak için bir liste oluşturuyoruz.
            List<Shape> shapes = new List<Shape>
            {
                new Circle(5), // 5 birim yarıçaplı bir daire
                new Rectangle(4, 6), // 4x6 boyutlarında bir dikdörtgen
                new Triangle(3, 4) // 3 birim tabanlı ve 4 birim yüksekliğinde bir üçgen
            };

            // Kullanıcıya hoş geldin mesajı
            Console.WriteLine("Welcome to the Shape Gallery!");
            Console.WriteLine("Let's explore our shapes and their areas:\n");

            // Tüm şekilleri döngü ile gezerek, her bir şekli çizdiriyoruz ve alanını hesaplıyoruz.
            foreach (var shape in shapes)
            {
                shape.Draw(); // Şekli çiz (konsola yazdırma)
                Console.WriteLine($"Area: {shape.CalculateArea():F2}"); // Alanı hesapla ve 2 ondalık basamakla göster
                Console.WriteLine();
            }

            // Programı kapatmadan önce kullanıcıdan bir tuşa basmasını istiyoruz.
            Console.WriteLine("Press any key to exit the Shape Gallery...");
            Console.ReadKey(); // Kullanıcı herhangi bir tuşa basana kadar beklemesini sağlayalım.
        }
    }
}
