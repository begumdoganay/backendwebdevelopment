using System;

class Program
{
    static void Main()
    {
        // Kullanıcıdan limit değeri alınıyor
        Console.Write("Bir limit değeri giriniz: ");
        int limit = int.Parse(Console.ReadLine());

        // Negatif bir limit girildiyse kullanıcıya bilgi veriyoruz
        if (limit < 0)
        {
            Console.WriteLine("\nNegatif bir limit girdiniz, döngü mantığı gereği while döngüsü hiç çalışmayacaktır.");
        }

        // While döngüsü ile çözüm
        #region While Döngüsü
        Console.WriteLine("\nWhile Döngüsü:");
        int sayac = 0;
        while (sayac <= limit)
        {
            Console.WriteLine($"Sayaç: {sayac}, Ben bir Patikalıyım");
            sayac++;
        }
        #endregion

        // Do-While döngüsü ile çözüm yapalımmmm
        #region Do-While Döngüsü
        Console.WriteLine("\nDo-While Döngüsü:");
        sayac = 0;
        do
        {
            Console.WriteLine($"Sayaç: {sayac}, Ben bir Patikalıyım");
            sayac++;
        } while (sayac <= limit);
        #endregion

        // Konsol ekranında sonucu görmek için gereken,,,,
        Console.ReadLine();
    }
}

/* 
Yorum yapalım efenim bilgilenelim:

1. While döngüsü koşulu kontrol ederek çalışmaya başlar. Çalışma mantığı budur. Eğer limit negatifse (örneğin -5), döngü hiç çalışmayacak ve ekrana bir şey yazdırmayacaktır.

2. Do-While döngüsü ise önce bir kez çalışır, sonra koşulu kontrol eder. Negatif bir limit olsa bile, sayaç değeri en az bir kez ekrana yazdırılacaktır.

Örnek:
- Girdi: 5
  - While döngüsü: Sayaç 0'dan başlayarak 5'e kadar toplam 6 kez mesaj yazdıracaktır                
  - Do-While döngüsü: Sayaç 0'dan başlayarak 5'e kadar toplam 6 kez mesaj yazdırır.

- Girdi: -3
  - While döngüsü: Hiçbir şey yazdırmaz çünkü limit negatif.
  - Do-While döngüsü: 1 kez Sayaç: 0, Ben bir Patikalıyım mesajı yazdırır.
*/



/* 
 Negatif limit girildiğinde while döngüsü hiç çalışmazken, do-while döngüsü en az bir kez çalışır.
 Limit pozitif olduğunda her iki döngü de benzer şekilde çalışacaktır.
*/