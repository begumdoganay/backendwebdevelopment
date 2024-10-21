using System;
using System.Collections.Generic;

public class PraticOfList2
{
    // Kahve menüsü oluşturur
    public static List<string> CreateCoffeeMenu(int numberOfCoffees)
    {
        List<string> coffeeNames = new List<string>(); // Liste oluşturuldu, devammm 

        for (int i = 0; i < numberOfCoffees; i++) // Kullanıcıdan belirli sayıda girdi al
        {
            string coffee = GetCoffeeName(i + 1); // Girdi al
            coffeeNames.Add(coffee); // Girdiyi listeye ekle
        }

        return coffeeNames; // Listeyi döndür
    }

    // Kullanıcıdan kahve adı alır
    private static string GetCoffeeName(int index)
    {
        Console.Write($"Bir kahve çeşidi girin (#{index}): ");
        string coffeeName = Console.ReadLine()?.Trim(); // Girdiyi al ve boşlukları temizle, hatalı sonuç almasını önle 

        // Boş girdi kontrolü
        while (string.IsNullOrEmpty(coffeeName))
        {
            Console.WriteLine("Kahve adı boş olamaz. Lütfen tekrar girin.");
            Console.Write($"Bir kahve çeşidi girin (#{index}): ");
            coffeeName = Console.ReadLine()?.Trim(); // Tekrar girdi al
        }

        return coffeeName; // Geçerli kahve adını sisteme dahil et ve döndürrr
    }

    // Kahve menüsünü ekrana yazdırır
    public static void DisplayCoffeeMenu(List<string> menu)
    {
        if (menu.Count == 0)
        {
            Console.WriteLine("Menüde kahve yok.");
            return;
        }

        Console.WriteLine("Kahve Menüsü:");
        foreach (string coffee in menu)
        {
            Console.WriteLine($"===>>> {coffee}");
        }
    }

    public static void Main(string[] args)
    {
        const int numberOfCoffees = 5; // Kullanıcıdan alınacak kahve sayısı
        List<string> menuCoffee = CreateCoffeeMenu(numberOfCoffees); // Liste oluşturuldu
        DisplayCoffeeMenu(menuCoffee); // Liste okundu
        Console.ReadKey();
    }
   
}
