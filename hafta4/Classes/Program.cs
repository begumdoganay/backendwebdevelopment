namespace Classes
{

    using System;

    public class Person
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }

        public Person(string ad, string soyad, DateTime dogumTarihi)
        {
            Ad = ad;
            Soyad = soyad;
            DogumTarihi = dogumTarihi;
        }

        public override string ToString()
        {
            return $"{Ad} {Soyad}, Doğum Tarihi: {DogumTarihi.ToShortDateString()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Öğrenci nesneleri oluşturalım
            Person ogrenci1 = new Person("Zeynep", "Yıldırım", new DateTime(2000, 5, 15));
            Person ogrenci2 = new Person("Emre", "Kaya", new DateTime(2001, 8, 22));
            Person ogrenci3 = new Person("Elif", "Öztürk", new DateTime(2002, 3, 7));
            Person ogrenci4 = new Person("Ahmet", "Çelik", new DateTime(2000, 11, 30));

            // Öğretmen nesneleri oluşturalım
            Person ogretmen1 = new Person("Ayşe", "Sarıoğlu", new DateTime(1980, 3, 10));
            Person ogretmen2 = new Person("Mehmet", "Yılmaz", new DateTime(1975, 11, 30));
            Person ogretmen3 = new Person("Fatma", "Aksoy", new DateTime(1985, 7, 18));
            Person ogretmen4 = new Person("Can", "Erdem", new DateTime(1978, 9, 5));

            // Bilgileri konsola yazdırma evresine geçelim
            Console.WriteLine("Öğrenciler:");
            Console.WriteLine(ogrenci1);
            Console.WriteLine(ogrenci2);
            Console.WriteLine(ogrenci3);
            Console.WriteLine(ogrenci4);

            Console.WriteLine("\nÖğretmenler:");
            Console.WriteLine(ogretmen1);
            Console.WriteLine(ogretmen2);
            Console.WriteLine(ogretmen3);
            Console.WriteLine(ogretmen4);

            Console.ReadKey();
        }
    }
}

// Sistemli bir şekilde sonuç elde edelim, kısa ve öz