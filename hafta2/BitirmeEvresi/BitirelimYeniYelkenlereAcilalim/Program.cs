using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("----- Merhaba, Uygulama Başladı! -----\n");

        // 1 - Basit bir selamlaşmayla işe başlayalım
        Task1();

        // 2 - İsim ve yaş bilgisini edinelim
        Task2();

        // 3 - Rastgele bir sayı seçelim
        Task3();

        // 4 - 3'e bölümden kalanı bulmaya ulaşalım 
        Task4();

        // 5 - Yaş kontrolü yapalım
        Task5();

        // 6 - Eğlenceli bir mesaj tekrarı
        Task6();

        // 7 - İsim değiştirme oyunu
        Task7();

        // 8 - Değer döndürmeyen bir metot
        Task8();

        // 9 - İki sayının toplamı
        Console.WriteLine("Toplam: " + Task9(5, 10));

        // 10 - Boolean değer kontrolü
        Console.WriteLine(Task10(true));

        // 11 - En yaşlı kişiyi bulalım
        Console.WriteLine("En Yaşlı: " + Task11(25, 32, 18));

        // 12 - En büyük sayıyı bulma
        Console.WriteLine("En Büyük: " + Task12());

        // 13 - İsimlerin yerlerini değiştirelim
        Task13();

        // 14 - Sayının çift mi, tek mi olduğunu bulma
        Console.WriteLine("Çift mi? " + Task14(5));

        // 15 - Gidilen yolu hesaplayalım
        Console.WriteLine("Gidilen Yol: " + Task15(60, 2) + " km");

        // 16 - Dairenin alanını bulma
        Console.WriteLine("Daire Alanı: " + Task16(10));

        // 17 - Metni büyük ve küçük harfle yazdıralım
        Task17();

        // 18 - Fazla boşlukları temizleyelim
        Task18();

        Console.WriteLine("\n----- Uygulama Sona Erdi, Hoşça Kal! -----");
    }

    static void Task1()
    {
        Console.WriteLine("Merhaba! Nasılsın? İyiyim, sen nasılsın?");
    }

    static void Task2()
    {
        string name = "Begüm";
        int age = 25;
        Console.WriteLine($"Benim adım {name}, yaşım ise {age}.");
    }

    static void Task3()
    {
        Console.WriteLine($"Bugün şanslı sayım: {new Random().Next(1, 100)}!");
    }

    static void Task4()
    {
        int randomNumber = new Random().Next(1, 100);
        Console.WriteLine($"Rastgele Sayı: {randomNumber}, 3'e bölümünden kalan: {randomNumber % 3}");
    }

    static void Task5()
    {
        Console.Write("Yaşınızı öğrenebilir miyim? ");
        if (int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine(age > 18 ? "Aferin, yetişkinsin! " : "Hala çocukluk günlerindesin! ");
        }
        else
        {
            Console.WriteLine("Geçersiz yaş girişi.");
        }
    }

    static void Task6()
    {
        Console.WriteLine("Herhangi bir şeyler söyleyeyim:");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Bugünlerde hiiiiiiç kendime gelemiyorum, yaşlandım mı ne ayol.");
        }
    }

    static void Task7()
    {
        Console.Write("Birinci ismi gir lütfen: ");
        string name1 = Console.ReadLine();
        Console.Write("Şimdi ikinci ismi gir: ");
        string name2 = Console.ReadLine();

        // İsimleri değiştir
        (name1, name2) = (name2, name1);  // Tuple deconstruction

        Console.WriteLine($"İsimler yer değiştirdi: {name1} ve {name2}");
    }

    static void Task8()
    {
        Console.WriteLine("Ben değer döndürmem, ama umarım hoşuna gider! Adım hıdır, elimden gelen budur. ");
    }

    static int Task9(int num1, int num2)
    {
        return num1 + num2;
    }

    static string Task10(bool value)
    {
        return value ? "Bu doğru!" : "Bu yanlış!";
    }

    static int Task11(int age1, int age2, int age3)
    {
        return Math.Max(age1, Math.Max(age2, age3));
    }

    static int Task12()
    {
        int largest = int.MinValue;
        string input;

        while (true)
        {
            Console.Write("Bir sayı gir, durmak için 'stop' yaz: ");
            input = Console.ReadLine();
            if (input.ToLower() == "stop") break;

            if (int.TryParse(input, out int number) && number > largest)
            {
                largest = number;
            }
            else
            {
                Console.WriteLine("Geçersiz sayı, lütfen tekrar deneyin.");
            }
        }

        return largest;
    }

    static void Task13()
    {
        Console.Write("İlk ismi yaz: ");
        string firstName = Console.ReadLine();
        Console.Write("İkinci ismi yaz: ");
        string secondName = Console.ReadLine();

        // İsimleri değiştir
        (firstName, secondName) = (secondName, firstName);  // Tuple deconstruction

        Console.WriteLine($"İsimler değişti: {firstName} ve {secondName}");
    }

    static bool Task14(int number)
    {
        return number % 2 == 0;
    }

    static double Task15(double speed, double time)
    {
        return speed * time;
    }

    static double Task16(double radius)
    {
        return Math.PI * radius * radius;
    }

    static void Task17()
    {
        string sentence = "Zaman bir Geri Sayım";
        Console.WriteLine($"Büyük harflerle: {sentence.ToUpper()}");
        Console.WriteLine($"Küçük harflerle: {sentence.ToLower()}");
    }

    static void Task18()
    {
        string greeting = "    Selamlar   ";
        Console.WriteLine($"Trimlenmiş metin: '{greeting.Trim()}'");
    }
}