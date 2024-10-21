# 🧮 Hafta 5 - Sayı Kareleme Uygulaması

## 🎯 Proje Hakkında

Merhaba kodlama kahramanları! 👋 Bu projemiz, C#'ta try-catch yapısını öğrenmek için süper eğlenceli bir yol. Kullanıcıdan bir sayı alıp karesini hesaplıyoruz, ama hatalı girişlere karşı da kendimizi koruyoruz. Yani, hem matematiği hem de hata yönetimini aynı anda öğreniyoruz!

## 🌟 Özellikler

- Kullanıcıdan sayı alma
- Sayının karesini hesaplama
- Hatalı girişleri yakalama ve nazikçe uyarma
- Mükemmel karekökler için özel mesajlar
- Eğlenceli ve dostane kullanıcı arayüzü

## 🚀 Nasıl Çalıştırılır

1. Projeyi bilgisayarına indir
2. Visual Studio veya başka bir C# IDE'sinde aç
3. F5'e bas (ya da "Çalıştır" düğmesine tıkla)
4. Konsoldaki yönergeleri takip et ve sayılar girmeye başla!
5. Çıkmak istediğinde 'q' tuşuna bas

## 📚 Bu Haftanın Konusu: Try-Catch

Try-catch yapısı, programımızın çökmesini engelleyen süper kahraman gibidir! İşte nasıl çalışıyor:

- `try` bloğu: Riskli kodu buraya koyuyoruz. Yani, "Bu kod hata verebilir ama bir deneyelim" dediğimiz yer.
- `catch` bloğu: Eğer `try`'da bir hata olursa, bu blok devreye girer ve "Sorun yok, ben hallederim" der.

Projemizde try-catch'i şöyle kullanıyoruz:
- Kullanıcının girdiği değeri sayıya çevirmeye çalışıyoruz (riskli iş!)
- Eğer çeviremezsel, kullanıcıya nazikçe "Hey, bu bir sayı değil!" diyoruz.

## 💡 İpuçları

- Sadece tam sayılar değil, ondalıklı sayılar da girebilirsin!
- Çok büyük sayılar girersen ne olacağını merak ediyor musun? Dene ve gör! 😉
- Acaba kaç tane mükemmel karekök bulabileceksin?

## 💡<-- KODUMUZ BURADA -->
using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Number Squaring Application!");
        Console.WriteLine("Enter a number to see its square, or 'q' to quit.");

        while (true)
        {
            // Time to get some user input! What number will they choose? 🤔
            Console.Write("\nEnter a number: ");
            string input = Console.ReadLine();
            // Escape hatch! If they're tired of our mathematical fun, let them go
            if (input.ToLower() == "q")
            {
                Console.WriteLine("Thanks for playing with numbers! See you next time, math wizard! 🧙‍♂️");
                break;
            }
            // Let's dive into the world of squares! 🌟
            ProcessInput(input);
        }
    }
    static void ProcessInput(string input)
    {
        try
        {
            // Can we turn this input into a number? Let's find out! 🕵️‍♂️
            if (double.TryParse(input, out double number))
            {
                // Time for some magic! Let's square this bad boy
                double square = Math.Pow(number, 2);
                Console.WriteLine($"Ta-da! The square of {number} is {square} ✨");
                // Ooh, is it a perfect square? Let's check!
                if (Math.Sqrt(square) % 1 == 0)
                {
                    Console.WriteLine($"Holy moly! {number} is a perfect square root! You've hit the jackpot! 🎰");
                }
            }
            else
            {
                // Oops, that's not a number. Let's complain!
                throw new FormatException("That's not a number, silly!");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Whoopsie! That's not a number. Try again, but this time with actual digits! 🔢");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Wow, that number is too big (or small)! Are you trying to break the universe? 🌌");
        }
        catch (Exception ex)
        {
            // Something went terribly wrong. Time to blame the intern!
            Console.WriteLine($"Uh oh, something weird happened: {ex.Message}");
            Console.WriteLine("Let's pretend that didn't happen and try again, shall we? 😅");
        }
    }
}  

## 🎭 Projeyi Geliştirme Fikirleri

- Sayının küpünü de hesaplayabilir misin?
- Kullanıcının kaç kere hatalı giriş yaptığını sayabilir misin?
- Belki bir "en büyük kare" yarışması ekleyebilirsin?

## 🤓 Son Söz

Bu proje ile hem matematiği eğlenceli hale getirdik hem de programlamada çok önemli bir konuyu öğrendik. Artık hatalar sizi korkutmasın! Kod yazmaya devam edin ve unutmayın: Her hata, yeni bir öğrenme fırsatıdır! 

Sorularınız mı var? Fikirlerinizi paylaşmak mı istiyorsunuz? Öğretmeninize sormaktan çekinmeyin. Kod yazmaya devam! 💻✨