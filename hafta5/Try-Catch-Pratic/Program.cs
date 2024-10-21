namespace Try_Catch_Pratic
{

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
}
