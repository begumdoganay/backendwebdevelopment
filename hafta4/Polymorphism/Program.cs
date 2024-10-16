using System;
using System.Collections.Generic;

namespace PolymorphismExample
{
    // Tüm şekiller için soyut temel sınıf
    public abstract class Shape
    {
        // Alan hesaplama metodu (Her şekil için farklı hesaplanacak)
        public abstract double CalculateArea();

        // Şekli çizme metodu (Her şekil için farklı çizilecek)
        public abstract void Draw();
    }

    // Daire sınıfı (Circle) - Shape sınıfından türetiliyor
    public class Circle : Shape
    {
        public double Radius { get; set; } // Dairenin yarıçapı

        // Yapıcı metot (constructor), dairenin yarıçapını alır.
        public Circle(double radius)
        {
            Radius = radius;
        }

        // Alan hesaplama: π * r^2
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        // Daireyi çiz (konsola yazdırma)
        public override void Draw()
        {
            Console.WriteLine($"Drawing a circle with radius {Radius}");
        }
    }

    // Dikdörtgen sınıfı (Rectangle) - Shape sınıfından türetiliyor
    public class Rectangle : Shape
    {
        public double Width { get; set; } // Genişlik
        public double Height { get; set; } // Yükseklik

        // Yapıcı metot, genişlik ve yüksekliği alır.
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        // Alan hesaplama: genişlik * yükseklik
        public override double CalculateArea()
        {
            return Width * Height;
        }

        // Dikdörtgeni çiz (konsola yazdırma)
        public override void Draw()
        {
            Console.WriteLine($"Drawing a rectangle with width {Width} and height {Height}");
        }
    }

    // Üçgen sınıfı (Triangle) - Shape sınıfından türetiliyor
    public class Triangle : Shape
    {
        public double Base { get; set; } // Taban uzunluğu
        public double Height { get; set; } // Yükseklik

        // Yapıcı metot, taban ve yüksekliği alır.
        public Triangle(double @base, double height) // 'base' anahtar kelimesi çakışmasını önlemek için @ kullanıyoruz
        {
            Base = @base;
            Height = height;
        }

        // Alan hesaplama: (0.5 * taban * yükseklik)
        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }

        // Üçgeni çiz (konsola yazdırma)
        public override void Draw()
        {
            Console.WriteLine($"Drawing a triangle with base {Base} and height {Height}");
        }
    }

    // Ana program
    class Program
    {
        static void Main(string[] args)
        {
            // Şekilleri tutmak için bir liste oluşturuyoruz.
            List<Shape> shapes = new List<Shape>
            {
                new Circle(5),       // 5 birim yarıçaplı daire
                new Rectangle(4, 6), // 4x6 boyutunda dikdörtgen
                new Triangle(3, 4)   // 3 birim tabanlı ve 4 birim yüksekliğinde üçgen
            };

            // Hoş geldiniz mesajı
            Console.WriteLine("Welcome to the Shape Gallery!");
            Console.WriteLine("Let's explore our shapes and their areas:\n");

            // Şekilleri döngüyle gezerek çizim ve alan hesaplama işlemi yapıyoruz.
            foreach (var shape in shapes)
            {
                shape.Draw(); // Şekli çizdir
                Console.WriteLine($"Area: {shape.CalculateArea():F2}"); // Alanı hesapla ve 2 ondalık basamak göster
                Console.WriteLine();
            }

            // Çıkış için kullanıcıdan tuşa basmasını bekliyoruz.
            Console.WriteLine("Press any key to exit the Shape Gallery...");
            Console.ReadKey();
        }
    }
}
