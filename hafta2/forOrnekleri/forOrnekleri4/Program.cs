using System;

class Program
{
    static void Main()
    {
        int toplam = 0;

        for (int i = 50; i <= 150; i++)
        {
            toplam += i;
        }

        Console.WriteLine($"50 ile 150 arasındaki tüüüüüm sayıların toplamı: \n" + toplam);

        Console.ReadLine();
    }
}
