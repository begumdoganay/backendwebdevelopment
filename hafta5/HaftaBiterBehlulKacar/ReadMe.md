Car Production Program
Overview
This program simulates a car production system where users can create car objects with specified attributes. It prompts the user to enter details about the car, including its serial number, brand, model, color, and number of doors. The program maintains a list of produced cars and displays their details upon completion.

Features
User Input: The program interacts with the user to gather information about cars.
Automatic Production Date: The production date is automatically set to the current date and time when a car is created.
Input Validation: Ensures that the number of doors is a valid positive integer.
Repeatable Process: Users can continue to produce cars or exit the program at any time.
Summary Display: At the end, the program displays the serial numbers and brands of all produced cars.
Requirements
.NET framework or a compatible C# environment to run the program.
Program Flow
The program prompts the user to decide whether they want to produce a car (input 'e' for yes, 'h' for no). It is case insensitive.
If the user opts to exit, the program ends.
If the user chooses to produce a car, they are prompted to enter the following details:
Serial Number
Brand
Model
Color
Number of Doors
The production date is automatically set at the time of car creation.
Input for the number of doors is validated to ensure it is a positive integer. If invalid, an error message is displayed, and the user is prompted again.
The created car object is added to a list of cars.
The user is then asked if they want to produce another car. If yes, the process repeats; if no, the program displays the serial numbers and brands of all produced cars.
Example Usage
plaintext

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