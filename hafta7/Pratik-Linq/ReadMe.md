Week 7 - LINQ Operations with Random Numbers 🎲
Overview
This week's project focuses on LINQ (Language Integrated Query) operations in C#. We've created a fun and interactive program that demonstrates various LINQ queries using a randomly generated list of numbers.
Learning Objectives 📚

Understanding LINQ basics
Working with random number generation
Implementing different query operations
Filtering and transforming data collections

Features ⭐
Our program includes the following LINQ operations:

Generating random numbers
Filtering even numbers
Filtering odd numbers
Finding negative numbers
Finding positive numbers
Filtering numbers in a specific range (15-22)
Computing squares of numbers

How It Works 🛠️
The program creates a list of 10 random numbers between -30 and 30, then performs various LINQ operations to filter and transform these numbers. Each operation is clearly commented and produces user-friendly console output.
Requirements 📋

.NET Framework/Core
Basic understanding of C# syntax
Visual Studio or any C# compatible IDE

Running the Program 🚀

Clone or download the repository
Open the solution in your preferred IDE
Build and run the program
Watch as the magic of LINQ unfolds in your console!

Code 💻
Here's the complete code implementation:
csharpCopyusing System;
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

Tips 💡

Try modifying the range of random numbers
Experiment with different LINQ operations
Add your own filtering conditions
Play with the output formatting

Happy Coding! 🎉
Feel free to experiment with the code and explore more LINQ operations. Remember, practice makes perfect!

Created with ❤️ for Week 7 of C# Learning Journey
