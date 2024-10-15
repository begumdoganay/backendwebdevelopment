using System;
using System.Globalization; // Kültürel farklar için gerekli kütüphane. 

namespace PrivateRepo_FundamentalsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu(); // Let's call the main menu to start the program.
        }

        // Firstly, creating the main menu.
        static void MainMenu()
        {
            while (true) // This while loop will keep showing the menu until the user chooses to exit.
            {
                Console.WriteLine("\n\r\r ----   Welcome to Begüm Doğanay's Sooo Basic Application!  ----\r\r");
                Console.WriteLine("                                   <--- Main Menu --->                                          ");
                Console.WriteLine("Which program would you like to run? Press the number of your choice:   ");
                Console.WriteLine("1 - Random Number Guessing Game: Let's see if our guessing skills are strong or not?");
                Console.WriteLine("2 - Run the Calculator and check some basic math.");
                Console.WriteLine("3 - Calculate the average of some simple numbers.");
                Console.WriteLine("4 - Exit the application gracefully.");
                Console.Write("Choose an option (1-4): ");

                string choice = Console.ReadLine() + "";

                if (choice == "1")
                {
                    RandomNumberGame(); // If user selects 1, the guessing game will start.
                }
                else if (choice == "2")
                {
                    Calculator(); // If user selects 2, the calculator will start
                }
                else if (choice == "3")
                {
                    AverageCalculator(); // If the user selects 3, the average calculator will run.
                }
                else if (choice == "4")
                {
                    break; // If the user selects 4, the program will exit the while loop, ending the application.
                }
                else
                    Console.WriteLine("Invalid choice, please pick a number between 1 and 4.");
            }
        }

        // Starting the Random Number Guessing Game
        static void RandomNumberGame()
        {
            Random random = new Random(); // Generate a random number.
            int secretNumber = random.Next(1, 101); // The random number will be between 1 and 100.
            int guessLimit = 5; // The user has 5 chances to guess.

            while (guessLimit > 0) // Loop until the user runs out of tries.
            {
                Console.Write($"Enter your guess (Remaining tries: {guessLimit}): ");
                int guess;

                if (!int.TryParse(Console.ReadLine(), out guess) || guess < 1 || guess > 100)
                {
                    Console.WriteLine("Please enter a valid number between 1 and 100!");
                    continue;
                }

                if (guess == secretNumber)
                {
                    Console.WriteLine("Congratulations! You guessed the correct number.");
                    break;
                }
                else if (guess < secretNumber)
                {
                    Console.WriteLine("Try a higher number.");
                }
                else
                {
                    Console.WriteLine("Try a lower number.");
                }

                guessLimit--;
            }

            if (guessLimit == 0)
            {
                Console.WriteLine($"Sorry, the correct number was --> {secretNumber}.");
            }
        }

        // Let's implement the Calculator function now
        static void Calculator()
        {
            Console.Write("Enter the first number: ");
            double num1 = GetNumber(); // We use a helper function to ensure the input is valid.

            Console.Write("Enter the second number: ");
            double num2 = GetNumber(); // Again, using the helper to get valid input.

            Console.Write("Choose an operation (+, -, *, /): ");
            string operation = Console.ReadLine() + "";
            double result = 0;
            bool validOperation = true;

            if (operation == "+") result = num1 + num2;
            else if (operation == "-") result = num1 - num2;
            else if (operation == "*") result = num1 * num2;
            else if (operation == "/" && num2 != 0) result = num1 / num2; // Handle division by zero.
            else
            {
                Console.WriteLine(num2 == 0 ? "Cannot divide by zero!" : "Invalid operation.");
                validOperation = false;
            }

            if (validOperation) Console.WriteLine($"The result is: {result}");
        }

        // Average Calculator: Simple method to calculate average of three grades
        static void AverageCalculator()
        {
            double grade1 = GetGrade("First");
            double grade2 = GetGrade("Second");
            double grade3 = GetGrade("Third");

            double average = (grade1 + grade2 + grade3) / 3;
            Console.WriteLine($"Your average grade is: {average:F2}");

            string letterGrade = CalculateLetterGrade(average);
            Console.WriteLine($"Your letter grade is: {letterGrade}");
        }

        // Helper function to get a valid number input from the user.
        static double GetNumber()
        {
            double number;
            // Kullanıcının girdiği sayıyı, nokta (.) ile ondalık ayracı olarak algılayan bir parse işlemi.
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out number))
            {
                Console.Write("Please enter a valid number: ");
            }
            return number;
        }

        // Helper function to get a valid grade between 0 and 100 from the user.
        static double GetGrade(string course)
        {
            double grade;
            Console.Write($"Enter the {course} course grade (0-100): ");
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out grade) || grade < 0 || grade > 100)
            {
                Console.WriteLine("Please enter a valid grade between 0 and 100!");
            }
            return grade;
        }

        // Function to calculate the letter grade based on the numeric average.
        static string CalculateLetterGrade(double average)
        {
            if (average >= 90) return "AA";
            else if (average >= 85) return "BA";
            else if (average >= 80) return "BB";
            else if (average >= 75) return "CB";
            else if (average >= 70) return "CC";
            else if (average >= 65) return "DC";
            else if (average >= 60) return "DD";
            else if (average >= 55) return "FD";
            return "FF";
        }
    }
}
