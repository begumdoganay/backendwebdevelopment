Car Production Program
Overview
This program simulates a car production system where users can create car objects with specified attributes. It prompts the user to enter details about the car, including its serial number, brand, model, color, and number of doors.

Features
User Input: Interacts with users to gather car information.
Automatic Production Date: Sets the production date to the current time.
Input Validation: Ensures the number of doors is a valid positive integer.
Repeatable Process: Users can produce multiple cars or exit at any time.
Summary Display: Shows the serial numbers and brands of all produced cars.
Requirements
.NET framework or any compatible C# environment.
Program Flow
User Prompt: Asks if the user wants to produce a car (input 'e' for yes, 'h' for no). Case insensitive.
Exit Option: If the user chooses 'h', the program ends.
Car Details: If 'e', prompts for:
Serial Number
Brand
Model
Color
Number of Doors
Production Date: Automatically recorded at creation.
Input Validation: Validates door count; prompts again if invalid.
List of Cars: Adds created car objects to a list.
Repeat or Exit: Asks if the user wants to produce another car. If yes, repeats; if no, displays details of all produced cars

Copy
Do you want to produce a car? (Y/N): Y
Serial Number: ABC123
Brand: Toyota
Model: Corolla
Color: Blue
Number of Doors: 4
Car produced successfully!

Do you want to produce another car? (Y/N): N

Produced Cars:
Serial Number: ABC123, Brand: Toyota
Code Structure
csharp

Copy
using System;
using System.Collections.Generic;

namespace HaftaBiterBehlulKacar
{
    public class Car
    {
        public DateTime ProductionDate { get; private set; }
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int DoorCount { get; set; }

        public Car()
        {
            ProductionDate = DateTime.Now;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            while (true)
            {
                Console.Write("Do you want to produce a car? (Y/N): ");
                string response = Console.ReadLine()?.Trim().ToUpper();

                if (response == "N")
                {
                    Console.WriteLine("Thank you for using the car production program. Goodbye!");
                    break;
                }
                else if (response == "Y")
                {
                    Car newCar = new Car();

                    Console.Write("Serial Number: ");
                    newCar.SerialNumber = Console.ReadLine()?.Trim();

                    Console.Write("Brand: ");
                    newCar.Brand = Console.ReadLine()?.Trim();

                    Console.Write("Model: ");
                    newCar.Model = Console.ReadLine()?.Trim();

                    Console.Write("Color: ");
                    newCar.Color = Console.ReadLine()?.Trim();

                    bool validDoorCount = false;
                    while (!validDoorCount)
                    {
                        Console.Write("Number of Doors: ");
                        string doorCountInput = Console.ReadLine()?.Trim();

                        if (int.TryParse(doorCountInput, out int doorCount) && doorCount > 0)
                        {
                            newCar.DoorCount = doorCount;
                            validDoorCount = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid positive number for the door count.");
                        }
                    }

                    cars.Add(newCar);
                    Console.WriteLine("Car produced successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid response. Please enter 'Y' to produce a car or 'N' to exit.");
                }
            }

            Console.WriteLine("\nProduced Cars:");
            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine($"Serial Number: {car.SerialNumber}, Brand: {car.Brand}, Production Date: {car.ProductionDate}");
                }
            }
            else
            {
                Console.WriteLine("No cars were produced.");
            }
        }
    }
}
