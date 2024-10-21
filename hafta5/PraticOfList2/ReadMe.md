Pratik - Lists 2
Bir Kahve İçsek Bize İyi Gelecek!
Bu uygulama, kullanıcıdan konsoldan gireceği 5 farklı kahve ismi ile bir liste oluşturarak, bu listeyi ekrana yazdırmayı amaçlamaktadır. Kahve tutkunları için hazırlandığı bu program, kullanıcı etkileşimi ile kahve çeşitlerini kaydeder ve gösterir.

İçindekiler: 
Amaç
Kullanım
Örnek Veri Girişi
Örnek Program Çıktısı
Teknik Bilgiler
Amaç
Bu uygulama, kullanıcıların farklı kahve çeşitlerini kolayca kaydedebileceği ve görüntüleyebileceği bir programdır. Kullanıcıdan alınan girdi ile oluşturulan liste, kullanıcı deneyimini artırmayı hedefler.

Kullanım
Uygulamayı çalıştırın.
Konsolda sizden istenen 5 kahve ismini girin.
Tüm kahve çeşitleri ekranda listelenecektir.


Bir kahve çeşidi girin (1): Espresso
Bir kahve çeşidi girin (2): Cappuccino
Bir kahve çeşidi girin (3): Latte
Bir kahve çeşidi girin (4): Americano
Bir kahve çeşidi girin (5): Mocha



﻿using System;
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

Kahve Menüsü:
===>>> Espresso
===>>> Cappuccino
===>>> Latte
===>>> Americano
===>>> Mocha
Teknik Bilgiler
Programlama Dili: C#
Kütüphaneler: System, System.Collections.Generic
Kullanıcı Girdisi: Console.ReadLine()
Döngüler: for, foreach
Hata Kontrolü: Boş giriş kontrolü
Bu program, kullanıcıların kahve çeşitlerini kaydetmesine ve görüntülemesine yardımcı olurken, C# dilindeki temel listeler ve döngüler hakkında pratik yapma fırsatı sunar. Kahve severler için harika bir başlangıç! ☕️
