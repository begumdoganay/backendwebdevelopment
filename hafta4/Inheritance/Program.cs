using System;

// Let's start with our superstar base class. It's like the cool parent everyone wants!
public class BasePerson
{
    // These properties are like the family traits - everyone's got 'em!
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // This method is the family's signature move. It's so cool, the kids might want to remix it!
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Yo, I'm {FirstName} {LastName}. Nice to meet ya!");
    }
}

// Student class - aka "The Coolest Kid in School"
public class Student : BasePerson
{
    // Extra cool points for having a student number
    public int StudentNumber { get; set; }

    // Watch how we spice up the family's signature move
    public override void PrintInfo()
    {
        // Gotta respect the OG move first
        base.PrintInfo();
        Console.WriteLine($"Check out my awesome student number: {StudentNumber}. Jealous much?");
    }
}

// Teacher class - aka "The Coolest Adult in School"
public class Teacher : BasePerson
{
    // Money, money, money! (But probably not enough, let's be real)
    public decimal Salary { get; set; }

    // Teachers have their own way of showing off
    public override void PrintInfo()
    {
        // Respect to the OG move, always!
        base.PrintInfo();
        Console.WriteLine($"I make it rain with my salary of {Salary:C}. Well, more like a light drizzle...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Time to bring our cool cats to life!
        Student coolKid = new()
        {
            FirstName = "Johnny",
            LastName = "Bravo",
            StudentNumber = 42424 // The answer to life, the universe, and everything!
        };

        Teacher coolTeacher = new()
        {
            FirstName = "Betty",
            LastName = "Boop",
            Salary = 3000m // Let's hope this is weekly, not monthly!
        };

        Console.WriteLine("Spotlight on our cool student:");
        coolKid.PrintInfo();

        Console.WriteLine("\nAnd now, let's hear it for our awesome teacher:");
        coolTeacher.PrintInfo();

        // End of the show, folks!
        Console.WriteLine("\nAnd that's how we roll in the world of OOP! 🎤💧");
    }
}