using System;

class Program
{
    static void Main()
    {
        int tekSayıToplamı  = 0;
        int ciftSayıToplamı = 0;

        for (int i = 1; i <= 120; i++)
        {
            if (i % 2 == 0)
            {
                ciftSayıToplamı += i;  // Çift sayıları topluyor hooop
            }
            else
            {
                tekSayıToplamı += i;   // Tek sayıları topluyor hoooop
            }
        }

        Console.WriteLine("1 ile 120 arasındaki çift sayıların toplamı: " + ciftSayıToplamı);
        Console.WriteLine("1 ile 120 arasındaki tek sayıların toplamı:  " + tekSayıToplamı);

        Console.ReadLine();
    }
}
