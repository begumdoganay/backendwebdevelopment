namespace Pratik_Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            // Let's add a bit of luck factor to the mix! 😊
            Random random = new Random();

            // Now, let's pull 10 random numbers from our magic box
            // Numbers between -30 and 30 to make things more interesting!
            List<int> numbers = Enumerable.Range(1, 10)
                .Select(x => random.Next(-30, 31))
                .ToList();

            // First, let's see what we've got
            Console.WriteLine("🎲 Here are our randomly selected numbers:");
            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine();

            // Let's find even numbers - these are the ones happy to be divided by 2!
            var evenNumbers = numbers.Where(x => x % 2 == 0);
            Console.WriteLine("➡️ Even Numbers (Friends of 2):");
            Console.WriteLine(string.Join(", ", evenNumbers));
            Console.WriteLine();

            // Don't forget odd numbers - the ones who don't like being divided by 2!
            var oddNumbers = numbers.Where(x => x % 2 != 0);
            Console.WriteLine("➡️ Odd Numbers (The Lone Wolves):");
            Console.WriteLine(string.Join(", ", oddNumbers));
            Console.WriteLine();

            // Let's find our negative friends - the below-zero neighborhood 😄
            var negativeNumbers = numbers.Where(x => x < 0);
            Console.WriteLine("➡️ Negative Numbers (The Underground Crew):");
            Console.WriteLine(string.Join(", ", negativeNumbers));
            Console.WriteLine();

            // Can't forget the positive gang - those above zero
            var positiveNumbers = numbers.Where(x => x > 0);
            Console.WriteLine("➡️ Positive Numbers (The Uptown Residents):");
            Console.WriteLine(string.Join(", ", positiveNumbers));
            Console.WriteLine();

            // Special club members between 15 and 22
            var rangeNumbers = numbers.Where(x => x > 15 && x < 22);
            Console.WriteLine("➡️ VIP Zone (Greater than 15, less than 22):");
            Console.WriteLine(string.Join(", ", rangeNumbers));
            Console.WriteLine();

            // Our final show - every number dancing with itself! (Getting their squares)
            var squares = numbers.Select(x => x * x).ToList();
            Console.WriteLine("🎯 Grand Finale: Squares of Numbers (Self-multiplication party):");
            Console.WriteLine(string.Join(", ", squares));
        }
    }
}
