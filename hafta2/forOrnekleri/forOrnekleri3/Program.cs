using System;

class Program
{
    static void Main()
    {
        for (int i = 1; i <= 20; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine($"Şu an bu sayıyı bulduk   ->  {i}");
            }
        }
        Console.ReadLine();
    }
}
