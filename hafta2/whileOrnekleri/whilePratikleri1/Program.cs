using System;

class Program
{
    static void Main()
    {
        // 1. Adım: Konsol ekranına 10 kere "Kendime inanıyorum, ben bu yazılım işini hallederim!" yazdırma
        #region Adım 1
        Console.WriteLine("1. Adım: 10 kere mesaj yazdırma");
        int count = 0;
        while (count < 10)
        {
            Console.WriteLine("Kendime inanıyorum, ben bu yazılım işini hallederim!");
            count++;
        }
        #endregion

        // 2. Adım: 1 ile 20 arasındaki sayıları konsol ekranına yazdırma
        #region Adım 2
        Console.WriteLine("\n2. Adım: 1 ile 20 arasındaki sayıları yazdırma");
        int i = 1;
        while (i <= 20)
        {
            Console.WriteLine(i);
            i++;
        }
        #endregion

        // 3. Adım: 1 ile 20 arasındaki çift sayıları konsol ekranına yazdırma
        #region Adım 3
        Console.WriteLine("\n3. Adım: 1 ile 20 arasındaki çift sayıları yazdırma");
        i = 1;
        while (i <= 20)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
            i++;
        }
        #endregion

        // 4. Adım: 50 ile 150 arasındaki sayıların toplamını ekrana yazdırma
        #region Adım 4
        Console.WriteLine("\n4. Adım: 50 ile 150 arasındaki sayıların toplamını yazdırma");
        int toplam = 0;
        i = 50;
        while (i <= 150)
        {
            toplam += i;
            i++;
        }
        Console.WriteLine("50 ile 150 arasındaki sayıların toplamı: " + toplam);
        #endregion

        // 5. Adım: 1 ile 120 arasındaki tek ve çift sayıların toplamlarını ayrı ayrı yazdırma
        #region Adım 5
        Console.WriteLine("\n5. Adım: 1 ile 120 arasındaki tek ve çift sayıların toplamlarını yazdırma");
        int tekSayıToplam = 0;
        int ciftSayıToplam = 0;
        i = 1;
        while (i <= 120)
        {
            if (i % 2 == 0)
            {
                ciftSayıToplam += i;
            }
            else
            {
                tekSayıToplam += i;
            }
            i++;
        }
        Console.WriteLine("1 ile 120 arasındaki çift sayıların toplamı: " + ciftSayıToplam);
        Console.WriteLine("1 ile 120 arasındaki tek sayıların toplamı: " + tekSayıToplam);
        #endregion

        // Konsol ekranında sonucu görmek için
        Console.ReadLine();
    }
}
