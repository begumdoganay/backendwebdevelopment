using System;

namespace SportsAcademyExample
{
    /// <summary>
    /// Concrete class representing a Football Coach
    /// Inherits from the abstract Coach class
    /// </summary>
    public class FootballCoach : Coach
    {
        // Additional properties specific to football coaches
        public string PreferredFormation { get; set; }
        public string CoachingStyle { get; set; }

        /// <summary>
        /// Constructor for FootballCoach class
        /// </summary>
        /// <param name="name">First name of the coach</param>
        /// <param name="surname">Last name of the coach</param>
        /// <param name="yearsOfExperience">Years of coaching experience</param>
        /// <param name="preferredFormation">Preferred team formation (e.g., "4-4-2")</param>
        /// <param name="coachingStyle">Style of coaching (e.g., "Attacking")</param>
        public FootballCoach(
            string name,
            string surname,
            int yearsOfExperience,
            string preferredFormation = "4-3-3",
            string coachingStyle = "Attacking"
        ) : base(name, surname, yearsOfExperience, "Football", "UEFA Pro License")
        {
            PreferredFormation = preferredFormation;
            CoachingStyle = coachingStyle;
        }

        /// <summary>
        /// Implementation of abstract method for conducting training
        /// Specific to football training methodology
        /// </summary>
        public override void ConductTraining()
        {
            Console.WriteLine($"\n=== Football Training Session ===");
            Console.WriteLine($"Coach {Name} {Surname} is conducting football training:");
            Console.WriteLine("1. Warm-up exercises and stretching");
            Console.WriteLine("2. Technical drills: passing and ball control");
            Console.WriteLine("3. Tactical practice using {PreferredFormation} formation");
            Console.WriteLine("4. Practice match with focus on {CoachingStyle} style");
        }

        /// <summary>
        /// Implementation of abstract method for evaluating athletes
        /// Focuses on football-specific metrics
        /// </summary>
        public override void EvaluateAthletes()
        {
            Console.WriteLine($"\n=== Player Evaluation Session ===");
            Console.WriteLine("Evaluating players on:");
            Console.WriteLine("- Technical skills (passing, shooting, dribbling)");
            Console.WriteLine("- Tactical understanding");
            Console.WriteLine("- Physical fitness");
            Console.WriteLine("- Team coordination");
        }

        /// <summary>
        /// Override of virtual method for motivation
        /// Customized for football context
        /// </summary>
        public override void MotivateAthletes()
        {
            Console.WriteLine($"\n=== Team Motivation ===");
            Console.WriteLine($"Coach {Name} {Surname} gives an inspiring team talk:");
            Console.WriteLine("'Success in football is about passion, dedication, and teamwork!'");
        }

        /// <summary>
        /// Method specific to FootballCoach class
        /// Sets up team tactics for matches
        /// </summary>
        /// <param name="opponent">Name of the opposing team</param>
        public void SetupMatchTactics(string opponent)
        {
            Console.WriteLine($"\n=== Match Preparation against {opponent} ===");
            Console.WriteLine($"Setting up team in {PreferredFormation} formation");
            Console.WriteLine($"Implementing {CoachingStyle} tactics");
            Console.WriteLine("Analyzing opponent's weaknesses");
        }
    }

    // Example usage in a program
    public class Program
    {
        public static void Main(string[] args)
        {
            // Creating a new football coach instance
            FootballCoach coach = new FootballCoach(
                "Alex",
                "Ferguson",
                30,
                "4-4-2",
                "Attacking"
            );

            // Demonstrating various coach activities
            coach.DisplayCoachInfo();
            coach.ConductTraining();
            coach.EvaluateAthletes();
            coach.MotivateAthletes();
            coach.SetupMatchTactics("Real Madrid");
        }
    }
}