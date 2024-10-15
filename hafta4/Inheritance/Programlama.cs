using System;

namespace Inheritance
{
    // Our cool base class - the template for all the awesome people in our school!
    public class BasePerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Hey there! I'm {FirstName} {LastName}.");
        }
    }

    // Student class - for all those eager learners out there!
    public class Student : BasePerson
    {
        public int StudentNumber { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"My student number is {StudentNumber}. Ready to learn!");
        }
    }

    // Teacher class - because knowledge is power!
    public class Teacher : BasePerson
    {
        public decimal Salary { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"I'm a teacher and my salary is {Salary:C}. Time to inspire!");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Coolsville High! Let's meet some of our awesome people:");

            // Creating a motivated student
            Student student1 = new Student();
            student1.FirstName = "Emily";
            student1.LastName = "Johnson";
            student1.StudentNumber = 54321;

            // Creating another bright student
            Student student2 = new Student();
            student2.FirstName = "Michael";
            student2.LastName = "Chen";
            student2.StudentNumber = 98765;

            // Creating a passionate teacher
            Teacher teacher1 = new Teacher();
            teacher1.FirstName = "Sarah";
            teacher1.LastName = "Thompson";
            teacher1.Salary = 55000;

            // Creating another inspiring teacher
            Teacher teacher2 = new Teacher();
            teacher2.FirstName = "David";
            teacher2.LastName = "Rodriguez";
            teacher2.Salary = 60000;

            // Time for introductions!
            Console.WriteLine("\nLet's hear from our students:");
            student1.PrintInfo();
            student2.PrintInfo();

            Console.WriteLine("\nAnd now, let's meet our teachers:");
            teacher1.PrintInfo();
            teacher2.PrintInfo();

            Console.WriteLine("\nPress any key to end this awesome introduction!");
            Console.ReadKey();
        }
    }
}