🚗 Car Production Program
🎉 Overview
Welcome to the Car Production Program! This delightful application simulates a car factory where you, the user, can create your dream cars with all the bells and whistles. You’ll be prompted to enter details such as the serial number, brand, model, color, and number of doors for your shiny new vehicle!

🌟 Features
User Input: Interacts with you to gather fun car information.
Automatic Production Date: Automatically sets the production date to the current time—no time travel required!
Input Validation: Ensures the number of doors is a valid positive integer (because who wants a negative number of doors?).
Repeatable Process: Feel free to produce as many cars as your heart desires or exit whenever you're ready.
Summary Display: Finally, see a list of all the fabulous cars you’ve produced!
🛠️ Requirements
A .NET framework or any compatible C# environment to run this car factory magic!
🏁 Program Flow
User Prompt: Asks if you want to produce a car (just type 'e' for yes or 'h' for no). It’s case-insensitive, so no pressure!
Exit Option: If you choose 'h', the program bids you farewell and exits.
Car Details: If you choose 'e', you’ll be prompted to enter:
Serial Number
Brand
Model
Color
Number of Doors
Production Date: Automatically recorded at creation—because every car deserves a birthday!
Input Validation: This checks the door count; if it’s not valid, it’ll ask you to try again.
List of Cars: All the cars you create will be added to a special list just for you.
Repeat or Exit: Asks if you want to produce another car. If yes, the fun continues; if no, it shows off the details of your marvelous creations!
🎈 Example Usage


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
💻 Code Structure

********
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


🎊 Conclusion
This program is a fun and interactive way to simulate car production! Dive in, let your creativity run wild, and build your virtual car factory. Enjoy the ride! 🚀
