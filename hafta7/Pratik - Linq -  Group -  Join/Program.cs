using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
    // Student entity with extended properties
    public class Student
    {
        public int StudentId { get; set; }
        public required string StudentName { get; set; }
        public int ClassId { get; set; }
        public required string Email { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }

    // Class entity with extended properties
    public class Class
    {
        public int ClassId { get; set; }
        public required string ClassName { get; set; }
        public required string TeacherName { get; set; }
        public int Capacity { get; set; }
    }

    // Custom result model for joined data
    public class ClassStudentReport
    {
        public required string ClassName { get; set; }
        public required string TeacherName { get; set; }
        public int StudentCount { get; set; }
        public required List<string> StudentNames { get; set; }
        public bool IsAtCapacity => StudentCount >= Capacity;
        public int Capacity { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initialize sample data
            var students = new List<Student>
            {
                new Student { StudentId = 1, StudentName = "Ali Yılmaz", ClassId = 1, Email = "ali@school.com", EnrollmentDate = DateTime.Parse("2024-01-15") },
                new Student { StudentId = 2, StudentName = "Ayşe Demir", ClassId = 2, Email = "ayse@school.com", EnrollmentDate = DateTime.Parse("2024-01-16") },
                new Student { StudentId = 3, StudentName = "Mehmet Kaya", ClassId = 1, Email = "mehmet@school.com", EnrollmentDate = DateTime.Parse("2024-01-15") },
                new Student { StudentId = 4, StudentName = "Fatma Şahin", ClassId = 3, Email = "fatma@school.com", EnrollmentDate = DateTime.Parse("2024-01-17") },
                new Student { StudentId = 5, StudentName = "Ahmet Çelik", ClassId = 2, Email = "ahmet@school.com", EnrollmentDate = DateTime.Parse("2024-01-16") }
            };

            var classes = new List<Class>
            {
                new Class { ClassId = 1, ClassName = "Advanced Mathematics", TeacherName = "Prof. Özlem Yıldız", Capacity = 3 },
                new Class { ClassId = 2, ClassName = "Turkish Literature", TeacherName = "Dr. Kemal Şen", Capacity = 2 },
                new Class { ClassId = 3, ClassName = "Chemistry Lab", TeacherName = "Dr. Ayşe Aktaş", Capacity = 2 }
            };

            // Perform advanced LINQ group join with detailed reporting
            var classReports = classes.GroupJoin(
                students,
                c => c.ClassId,
                s => s.ClassId,
                (class_, studentsInClass) => new ClassStudentReport
                {
                    ClassName = class_.ClassName,
                    TeacherName = class_.TeacherName,
                    StudentCount = studentsInClass.Count(),
                    StudentNames = studentsInClass.Select(s => s.StudentName).ToList(),
                    Capacity = class_.Capacity
                })
                .OrderBy(r => r.ClassName);

            // Display detailed results
            Console.WriteLine("Class and Student Analysis Report");
            Console.WriteLine("================================\n");

            foreach (var report in classReports)
            {
                Console.WriteLine($"Class: {report.ClassName}");
                Console.WriteLine($"Teacher: {report.TeacherName}");
                Console.WriteLine($"Capacity Status: {report.StudentCount}/{report.Capacity} " +
                                $"({(report.IsAtCapacity ? "FULL" : "AVAILABLE")})");
                Console.WriteLine("Enrolled Students:");

                if (report.StudentNames.Any())
                {
                    foreach (var student in report.StudentNames)
                    {
                        Console.WriteLine($"  - {student}");
                    }
                }
                else
                {
                    Console.WriteLine("  No students enrolled");
                }
                Console.WriteLine();
            }
        }
    }
}