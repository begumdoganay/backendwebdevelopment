using System;
using System.Collections.Generic;

public class PraticOfList2
{
    // Kahve menüsü oluşturur
    public static List<string> CreateCoffeeMenu(int numberOfCoffees)
    {
        List<string> coffeeNames = new List<string>();

        for (int i = 0; i < numberOfCoffees; i++)
        {
            string coffee = GetCoffeeName(i + 1);
            coffeeNames.Add(coffee);
        }

        return coffeeNames;
    }

    // Kullanıcıdan kahve adı alır
    private static string GetCoffeeName(int index)
    {
        Console.Write($"Bir kahve çeşidi girin (#{index}): ");
        string coffeeName = Console.ReadLine()?.Trim();

        // Boş girdi kontrolü
        while (string.IsNullOrEmpty(coffeeName))
        {
            Console.WriteLine("Kahve adı boş olamaz. Lütfen tekrar girin.");
            Console.Write($"Bir kahve çeşidi girin (#{index}): ");
            coffeeName = Console.ReadLine()?.Trim();
        }

        return coffeeName;
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
        Console.Write("Kaç kahve çeşidi girmek istersiniz? ");
        if (int.TryParse(Console.ReadLine(), out int numberOfCoffees) && numberOfCoffees > 0)
        {
            List<string> menuCoffee = CreateCoffeeMenu(numberOfCoffees);
            DisplayCoffeeMenu(menuCoffee);
        }
        else
        {
            Console.WriteLine("Lütfen geçerli bir sayı girin.");
        }

        Console.ReadKey();
    }
}
