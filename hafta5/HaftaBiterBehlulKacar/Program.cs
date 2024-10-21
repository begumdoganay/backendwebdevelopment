using System;
using System.Collections.Generic;

namespace HaftaBiterBehlulKacar
{
    public class Car
    {
        // Properties of the Car class
        public DateTime ProductionDate { get; private set; } // Automatically set to the current date and time
        public string SerialNumber { get; set; } // Unique identifier for each car
        public string Brand { get; set; } // Brand of the car
        public string Model { get; set; } // Model of the car
        public string Color { get; set; } // Color of the car
        public int DoorCount { get; set; } // Number of doors on the car

        // Constructor that initializes the production date
        public Car()
        {
            ProductionDate = DateTime.Now; // Setting the production date automatically when the car is created
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // List to hold all produced cars
            List<Car> cars = new List<Car>();

            while (true)
            {
                // Asking the user if they want to produce a car
                Console.Write("Do you want to produce a car? (Y/N): ");
                string response = Console.ReadLine()?.Trim(); // Read user input and remove any extra spaces

                // Check if the user chose not to produce a car
                if (response == "N")
                {
                    // Exit the program
                    Console.WriteLine("Thank you for using the car production program. Goodbye!");
                    break;
                }
                // Check if the user wants to produce a car
                else if (response == "Y")
                {
                    Car newCar = new Car(); // Create a new Car object

                    // Collecting car details from the user
                    Console.Write("Serial Number: ");
                    newCar.SerialNumber = Console.ReadLine()?.Trim(); // Get the serial number

                    Console.Write("Brand: ");
                    newCar.Brand = Console.ReadLine()?.Trim(); // Get the brand

                    Console.Write("Model: ");
                    newCar.Model = Console.ReadLine()?.Trim(); // Get the model

                    Console.Write("Color: ");
                    newCar.Color = Console.ReadLine()?.Trim(); // Get the color

                    // Ensuring valid input for door count
                    bool validDoorCount = false; // Flag to check if the door count is valid
                    while (!validDoorCount)
                    {
                        Console.Write("Number of Doors: ");
                        string doorCountInput = Console.ReadLine()?.Trim(); // Get the door count input

                        // Check if the input is a valid integer
                        if (int.TryParse(doorCountInput, out int doorCount) && doorCount > 0)
                        {
                            newCar.DoorCount = doorCount; // Set the door count
                            validDoorCount = true; // Valid input received, exit the loop
                        }
                        else
                        {
                            // Prompt the user to enter a valid number
                            Console.WriteLine("Please enter a valid positive number for the door count.");
                        }
                    }

                    // Adding the new car object to the list of cars
                    cars.Add(newCar);
                    Console.WriteLine("Car produced successfully!"); // Confirmation message
                }
                else
                {
                    // Inform the user if their input was invalid
                    Console.WriteLine("Invalid response. Please enter 'Y' to produce a car or 'N' to exit.");
                }
            }

            // Printing the serial numbers and brands of the produced cars
            Console.WriteLine("\nProduced Cars:");
            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    // Display each car's serial number, brand, and production date
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