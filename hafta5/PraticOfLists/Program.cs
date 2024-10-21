using System;
using System.Collections.Generic;
using System.Linq;

namespace PatikaPlusGalaGecesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Davetli listesini oluşturmakla başlayalım 
                var davetliler = new List<string>
            {
                "Bülent Ersoy",
                "Ajda Pekkan",
                "Ebru Gündeş",
                "Hadise",
                "Hande Yener",
                "Tarkan",
                "Funda Arar",
                "Demet Akalın"
            };
            //Ee liste oluşturduğumuza göre yazdıralımm
                PrintDavetlilerListesi(davetliler);
            }
        // Verilen davetli listesini konsola yazdırır.
        static void PrintDavetlilerListesi(IReadOnlyList<string> davetliler)
            {
                const string baslik = "** Patika Plus Gala Gecesi Davetlileri **";
                const string cizgi = "----------------------------------------";

                Console.WriteLine(baslik);
                Console.WriteLine(cizgi);
            /*
                Console.WriteLine("For Döngüsü ile Yazdırma:");
                for (int i = 0; i < davetliler.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {davetliler[i]}");
                }
            */
                Console.WriteLine("\nForEach Döngüsü ile Yazdırma:");
                foreach (var isim in davetliler)
                {
                    Console.WriteLine($"- {isim}");
                }

                Console.WriteLine(cizgi);
                Console.WriteLine($"Davetli Sayısı: {davetliler.Count}");
                Console.WriteLine(cizgi);
            }
        
    }
}

// Bu kod, Patika Plus Gala gecesine katılacak davetlilerin listesini oluşturuyor.
// Davetliler Listesi, bir List<string> olarak tanımladım ve PrintDavetlilerListesi metodu ile ekrana gelecektir. 
// Metod, hem for hem de foreach döngüsü kullanarak davetlileri yazdırıyor, böylece daha çok seçenek sunuyor.
// Sonda ise  toplam davetli sayısını göstererek, gecenin ne kadar kalabalık olacağını da öğreniyoruz.
// Bu kod sayesinde gala gecesinde bir sürpriz yaşanmayacak, her şey kontrol altında! O zaman parti başlasın!

