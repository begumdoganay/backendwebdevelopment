using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Define an integer array with 10 elements
        int[] grid = new int[10];

        // Prompt the user to enter valid numbers
        Console.WriteLine("Give me 10 numbers for this array! Let's go :)");
        for (int i = 0; i < grid.Length; i++)
        {
            // Call the function to get the number from the user
            grid[i] = GetUserInput($"Number {i + 1}: ");
        }

        // Print the numbers entered by the user
        PrintNumbers("You entered the following numbers:", grid);

        // Let's add a new number as the 11th element
        int newValue = GetUserInput("Enter a new number to add to the array (11th element): ");
        Array.Resize(ref grid, grid.Length + 1); // Increase the size of the array
        grid[grid.Length - 1] = newValue; // Add the new number

        // Sort the array in descending order and print it
        var sortedGrid = Sort(grid); // Call the sorting function
        PrintNumbers("The numbers sorted in descending order are as follows:", sortedGrid);

        // End of the program message
        Console.WriteLine("The sorting is done! Hope everything is okay :D");
    }

    // Function to get a valid integer input from the user
    static int GetUserInput(string message)
    {
        int result;
        while (true) // Infinite loop until valid input is received
        {
            Console.Write(message); // Print the message to the user
            if (int.TryParse(Console.ReadLine(), out result)) // Validate the input
            {
                return result; // Return the valid input
            }
            // Inform the user about invalid input
            Console.WriteLine("You entered an invalid number. Please try again.");
        }
    }

    // Function to print the numbers to the console
    static void PrintNumbers(string message, int[] grid)
    {
        Console.WriteLine(message); // Print the message
        foreach (var value in grid) // Print each element of the array
        {
            Console.WriteLine(value);
        }
    }

    // Function to sort the array in descending order
    static int[] Sort(int[] grid)
    {
        Array.Sort(grid); // Sort the array
        Array.Reverse(grid); // Reverse it to get descending order
        return grid; // Return the sorted array
    }
}