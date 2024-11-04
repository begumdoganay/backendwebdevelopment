Week 7 - Turkish Music Platform Analysis 🎵
 
Project Description
This week's project analyzes data on a Turkish music platform using LINQ operations in C#. We've created a sophisticated program that processes and analyzes information about famous Turkish musicians, their genres, debut years, and album sales.
Learning Objectives 📚

Advanced LINQ operations
Clean code principles
Object-oriented programming concepts
Data analysis and filtering
Professional code documentation
Code organization and structure

Technical Features ⚙️

LINQ queries and methods
Custom class implementation
Method separation and organization
String formatting and presentation
Data filtering and sorting
Professional documentation

Core Functionalities 🎯

Artist Database Management

Structured data storage
Easy data access and manipulation
Flexible data model


Analysis Features

Filter artists by name prefix
Analyze sales performance
Timeline-based sorting
Genre-specific filtering
Statistical analysis


Data Presentation

Formatted console output
Clear result categorization
Visual separators and emojis
Professional data display



Code Structure 🏗️
plaintextCopyProject/
│
├── Artist Class/
│   ├── Properties (Name, MusicGenre, DebutYear, AlbumSales)
│   └── ToString() Override
│
├── Main Program/
│   ├── Database Initialization
│   └── Analysis Methods
│
└── Analysis Features/
    ├── Name-based Filtering
    ├── Sales Analysis
    ├── Timeline Analysis
    ├── Genre Filtering
    └── Result Presentation
Implementation Details 💻
csharpCopyusing System;
using System.Collections.Generic;
using System.Linq;


// Represents a musical artist with their career details

If you'd like to review my code, I'm leaving it below.
using System;
using System.Collections.Generic;
using System.Linq;

class Artist
{
    public string Name { get; set; }
    public string MusicType { get; set; }
    public int ReleaseYear { get; set; }
    public int AlbumSales { get; set; }
    public override string ToString()
    {
        return $"{Name} - {MusicType} ({ReleaseYear}) - {AlbumSales:N0} satış";
    }
}

class Program
{
    static void Main()
    {
        // Create our artist database
        var artists = new List<Artist>
        {
            new Artist { Name = "Ajda Pekkan", MusicType = "Pop", ReleaseYear = 1968, AlbumSales = 20000000 },
            new Artist { Name = "Sezen Aksu", MusicType = "Türk Halk Müziği / Pop", ReleaseYear = 1971, AlbumSales = 10000000 },
            new Artist { Name = "Funda Arar", MusicType = "Pop", ReleaseYear = 1999, AlbumSales = 3000000 },
            new Artist { Name = "Sertab Erener", MusicType = "Pop", ReleaseYear = 1994, AlbumSales = 5000000 },
            new Artist { Name = "Sıla", MusicType = "Pop", ReleaseYear = 2009, AlbumSales = 3000000 },
            new Artist { Name = "Serdar Ortaç", MusicType = "Pop", ReleaseYear = 1994, AlbumSales = 10000000 },
            new Artist { Name = "Tarkan", MusicType = "Pop", ReleaseYear = 1992, AlbumSales = 40000000 },
            new Artist { Name = "Hande Yener", MusicType = "Pop", ReleaseYear = 1999, AlbumSales = 7000000 },
            new Artist { Name = "Hadise", MusicType = "Pop", ReleaseYear = 2005, AlbumSales = 5000000 },
            new Artist { Name = "Gülben Ergen", MusicType = "Pop / Türk Halk Müziği", ReleaseYear = 1997, AlbumSales = 10000000 },
            new Artist { Name = "Neşet Ertaş", MusicType = "Türk Halk Müziği / Türk Sanat Müziği", ReleaseYear = 1960, AlbumSales = 2000000 }
        };
        
        // 1. Artists whose names start with 'S'
        Console.WriteLine("🎤 Adı 'S' ile başlayan şarkıcılar:");
        var sArtists = artists.Where(a => a.Name.StartsWith("S"));
        foreach (var artist in sArtists)
        {
            Console.WriteLine(artist);
        }
        Console.WriteLine();

        // 2. Artists with album sales of over 10 million
        Console.WriteLine("💿 Albüm satışları 10 milyon'un üzerinde olan şarkıcılar:");
        var highSales = artists.Where(a => a.AlbumSales >= 10000000);
        foreach (var artist in highSales)
        {
            Console.WriteLine(artist);
        }
        Console.WriteLine();

        // 3. Pre-2000 pop artists grouped by year and sorted alphabetically within groups
        Console.WriteLine("🎵 2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar (yıla göre gruplu):");
        var pre2000Pop = artists
            .Where(a => a.ReleaseYear < 2000 && a.MusicType.Contains("Pop"))
            .GroupBy(a => a.ReleaseYear)
            .OrderBy(g => g.Key); // Sort groups by year

        foreach (var yearGroup in pre2000Pop)
        {
            Console.WriteLine($"\n{yearGroup.Key} yılında çıkış yapanlar:");
            var sortedArtists = yearGroup.OrderBy(a => a.Name); // Sort artists within group by name
            foreach (var artist in sortedArtists)
            {
                Console.WriteLine($"  {artist}");
            }
        }
        Console.WriteLine();

        // 4. Artist with highest album sales
        Console.WriteLine("👑 En çok albüm satan şarkıcı:");
        var topSeller = artists.OrderByDescending(a => a.AlbumSales).First();
        Console.WriteLine(topSeller);
        Console.WriteLine();

        // 5. Newest and oldest artists
        Console.WriteLine("📅 En yeni ve en eski çıkış yapan şarkıcılar:");
        var newest = artists.OrderByDescending(a => a.ReleaseYear).First();
        var oldest = artists.OrderBy(a => a.ReleaseYear).First();
        Console.WriteLine($"En yeni: {newest}");
        Console.WriteLine($"En eski: {oldest}");
    }
}

Key LINQ Operations Used 🔍

Where() for filtering data
OrderBy() and OrderByDescending() for sorting
First() for selecting specific records
Contains() for string matching
StartsWith() for prefix matching

Required Skills 🛠️

C# fundamentals
LINQ basics
Object-oriented programming
Data structures
Console application development

Getting Started 🚀

Clone the repository
Open the solution in Visual Studio
Build and run the project
Explore the various analyses performed

Best Practices Implemented ✨

Clean Code principles
Single Responsibility Principle
Proper documentation
Consistent naming conventions
Organized code structure
Error handling
Professional output formatting

Future Enhancements 🔮

Add database integration
Implement more complex analyses
Create a user interface
Add data export features
Include statistical visualizations
Expand artist database

Contributing 🤝
Feel free to contribute to this project by:

Adding new analysis features
Improving existing code
Enhancing documentation
Adding new data presentation methods
Suggesting optimizations

Acknowledgments 👏
Special thanks to:

Patika.dev for the project idea
Turkish music industry for the inspiration
Our mentors and fellow learners


Created with ❤️ for Week 7 of C# Learning Journey
