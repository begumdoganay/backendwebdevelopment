using System;

public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    private int _doorCount;

    public int DoorCount
    {
        get { return _doorCount; }
        set
        {
            if (value == 2 || value == 4)
            {
                _doorCount = value;
            }
            else
            {
                Console.WriteLine($"Error: The number of doors must be 2 or 4. Entered value: {value}");
                _doorCount = -1;
            }
        }
    }

    public Car(string brand, string model, string color, int doorCount)
    {
        Brand = brand;
        Model = model;
        Color = color;
        DoorCount = doorCount;
    }

    public override string ToString()
    {
        return $"Brand: {Brand}, Model: {Model}, Color: {Color}, Door Count: {DoorCount}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Car Examples:");

        Car car1 = new Car("Toyota", "Corolla", "White", 4);
        Console.WriteLine(car1);

        Car car2 = new Car("Porsche", "911", "Red", 2);
        Console.WriteLine(car2);

        Car car3 = new Car("Honda", "Civic", "Blue", 3);
        Console.WriteLine(car3);
    }
}

