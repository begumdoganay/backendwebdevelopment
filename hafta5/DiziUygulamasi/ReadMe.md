# 🌟 Week 5 - Array Practice

## 📚 Overview
In this week's practice, we implemented a C# program that handles an array of integers. The program performs the following tasks:

1. **Defines an array** that can hold 10 integer values.
2. **Fills the array** using a `for` loop and displays the values using a `foreach` loop.
3. **Allows the user** to add a new integer as the 11th element in the array.
4. **Sorts the array** in descending order and prints the sorted values.

## 🎯 Objectives
- To understand how to work with **arrays** in C#.
- To practice using **loops** for data input and output.
- To implement **sorting functionality**.
- To enhance user interaction through **console input and output**.

## 🛠️ Implementation Steps

### Step 1: Define an Integer Array
We start by defining an integer array called `grid` that can hold 10 elements:

C#

int[] grid = new int[10];
Step 2: Fill the Array Using a Loop
Using a for loop, we prompt the user to enter 10 integer values. Each value is stored in the grid array.

C#

for (int i = 0; i < grid.Length; i++)
{
    grid[i] = GetUserInput($"Number {i + 1}: ");
}
We utilize a helper function GetUserInput to ensure that the input is valid:

C#

static int GetUserInput(string message)
{
    int result;
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out result))
        {
            return result;
        }
        Console.WriteLine("You entered an invalid number. Please try again.");
    }
}
Step 3: Add a New Value as the 11th Element
After collecting the initial 10 values, we allow the user to enter an additional integer, which becomes the 11th element in the array. We resize the array to accommodate this new value:

C#

int newValue = GetUserInput("Enter a new number to add to the array (11th element): ");
Array.Resize(ref grid, grid.Length + 1);
grid[grid.Length - 1] = newValue;
Step 4: Sort the Array in Descending Order
We sort the array using the built-in Array.Sort method, followed by Array.Reverse to arrange the values in descending order:

C#

Array.Sort(grid);
Array.Reverse(grid);
Step 5: Print the Sorted Values
Finally, we display the sorted values using the PrintNumbers function:

C#
static void PrintNumbers(string message, int[] grid)
{
    Console.WriteLine(message);
    foreach (var value in grid)
    {
        Console.WriteLine(value);
    }
}
📜 Complete Code
Here is the complete implementation of the program:

C#
using System;

class Program
{
    static void Main()
    {
        int[] grid = new int[10];

        Console.WriteLine("Give me 10 numbers for this array! Let's go :)");
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i] = GetUserInput($"Number {i + 1}: ");
        }

        PrintNumbers("You entered the following numbers:", grid);

        int newValue = GetUserInput("Enter a new number to add to the array (11th element): ");
        Array.Resize(ref grid, grid.Length + 1);
        grid[grid.Length - 1] = newValue;

        Array.Sort(grid);
        Array.Reverse(grid);
        PrintNumbers("The numbers sorted in descending order are as follows:", grid);

        Console.WriteLine("The sorting is done! Hope everything is okay :D");
    }

    static int GetUserInput(string message)
    {
        int result;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out result))
            {
                return result;
            }
            Console.WriteLine("You entered an invalid number. Please try again.");
        }
    }

    static void PrintNumbers(string message, int[] grid)
    {
        Console.WriteLine(message);
        foreach (var value in grid)
        {
            Console.WriteLine(value);
        }
    }
}
🎉 Conclusion
This week's practice provided hands-on experience with arrays, loops, and user input in C#. The program effectively demonstrates the ability to manage a collection of integers and perform operations such as sorting and resizing.
 
