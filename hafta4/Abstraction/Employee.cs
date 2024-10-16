using System;

namespace SportsAcademyExample
{
    /// <summary>
    /// Abstract base class representing a sports coach
    /// This class provides the basic structure for all types of coaches
    /// </summary>
    public abstract class Coach
    {
        // Properties for basic coach information
        public string Name { get; set; }
        public string Surname { get; set; }
        public int YearsOfExperience { get; set; }
        public string Specialization { get; set; }

        // Protected property to track coach's certification level
        protected string CertificationLevel { get; set; }

        /// <summary>
        /// Constructor to initialize a new coach
        /// </summary>
        /// <param name="name">First name of the coach</param>
        /// <param name="surname">Last name of the coach</param>
        /// <param name="yearsOfExperience">Years of coaching experience</param>
        /// <param name="specialization">Area of expertise</param>
        /// <param name="certificationLevel">Professional certification level</param>
        public Coach(string name, string surname, int yearsOfExperience,
                    string specialization, string certificationLevel)
        {
            Name = name;
            Surname = surname;
            YearsOfExperience = yearsOfExperience;
            Specialization = specialization;
            CertificationLevel = certificationLevel;
        }

        /// <summary>
        /// Abstract method that must be implemented by derived classes
        /// Defines how each type of coach conducts their training sessions
        /// </summary>
        public abstract void ConductTraining();

        /// <summary>
        /// Abstract method for coach's specific way of evaluating athletes
        /// </summary>
        public abstract void EvaluateAthletes();

        /// <summary>
        /// Virtual method that can be overridden by derived classes
        /// Provides basic motivation technique
        /// </summary>
        public virtual void MotivateAthletes()
        {
            Console.WriteLine($"Coach {Name} {Surname} is motivating the athletes!");
        }

        /// <summary>
        /// Common method for all coaches to display their information
        /// </summary>
        public void DisplayCoachInfo()
        {
            Console.WriteLine("\n=== Coach Information ===");
            Console.WriteLine($"Name: {Name} {Surname}");
            Console.WriteLine($"Specialization: {Specialization}");
            Console.WriteLine($"Experience: {YearsOfExperience} years");
            Console.WriteLine($"Certification Level: {CertificationLevel}");
        }

        /// <summary>
        /// Method to update coach's certification level
        /// </summary>
        /// <param name="newLevel">New certification level to be assigned</param>
        protected void UpdateCertification(string newLevel)
        {
            CertificationLevel = newLevel;
            Console.WriteLine($"Certification updated to: {newLevel}");
        }
    }
}