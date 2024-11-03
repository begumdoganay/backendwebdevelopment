# Week 7 - TV Series Management with LINQ 📺

## Project Description
A fun and interactive console application that helps manage and analyze Turkish TV series data using LINQ operations in C#. This project is a part of the Patikadev .NET learning path.

## Features 🌟

### Core Functionality
- List all TV series with detailed information
- Filter comedy series
- Group series by directors
- Analyze platform statistics
- Search series by name
- Find most productive years in TV series production

### Data Management
- Add new TV series
- Filter series by various criteria
- Perform complex queries using LINQ
- Display formatted results in console

## Getting Started 🚀

### Prerequisites
- .NET 6.0 or higher
- Visual Studio 2022 or any C# compatible IDE

### Installation
1. Clone the repository

git clone https://github.com/yourusername/week7-patikadev.git

2. Navigate to project directory
1. 
cd week7-patikadev

3. Build the project



4. Run the application
```bash
dotnet run
```

## Usage Examples 💡

### Adding a New Series
```csharp
var newSeries = new TVSeries 
{ 
    Name = "Awesome Show", 
    Year = 2024, 
    Genre = "Comedy", 
    Director = "Fun Director" 
};
YeniDiziEkle(diziler, newSeries);
```

### Searching for Series
```csharp
DiziAra(diziler, "Avrupa");  // Searches for series containing "Avrupa"
```

### Finding Most Productive Year
```csharp
EnVerimliYil(diziler);  // Shows the year with most TV series productions
```

## Project Structure 📁
```
Week7Project/
├── Program.cs           # Main application file
├── TVSeries.cs         # TV Series class definition
├── README.md           # Project documentation
└── .gitignore         # Git ignore file
```

## Contributing 🤝
1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact
Your Name - [@yourgithub](https://github.com/yourusername)
Project Link: [https://github.com/yourusername/week7-patikadev](https://github.com/yourusername/week7-patikadev)

## Acknowledgments 🙏
- Patika.dev for providing the learning path
- All Turkish TV series fans 📺
- Everyone who contributed to this project

## Complete Source Code 💻

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatikaflixApp
{
    // 📺 TV Series class - Holds identity information for each series
    public class TVSeries
    {
        public string Name { get; set; }         // Series name
        public int Year { get; set; }            // Production year
        public string Genre { get; set; }        // Genre
        public string StartYear { get; set; }    // Start year
        public string Director { get; set; }     // Director
        public string Platform { get; set; }     // Broadcasting platform
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 🎬 Let's prepare our series! Here are the most loved Turkish series...
            var series = new List<TVSeries>
            {
                new TVSeries { Name = "Avrupa Yakası", Year = 2004, Genre = "Comedy", StartYear = "2004", Director = "Yüksel Aksu", Platform = "Kanal D" },
                new TVSeries { Name = "Yalan Dünya", Year = 2012, Genre = "Comedy", StartYear = "2012", Director = "Gülseren Buda Başkaya", Platform = "Fox TV" },
                new TVSeries { Name = "Jet Sosyete", Year = 2018, Genre = "Comedy", StartYear = "2018", Director = "Gülseren Buda Başkaya", Platform = "TV8" },
                new TVSeries { Name = "Dadı", Year = 2006, Genre = "Comedy", StartYear = "2006", Director = "Yusuf Pirhasan", Platform = "Kanal D" },
                new TVSeries { Name = "Belalı Baldız", Year = 2007, Genre = "Comedy", StartYear = "2007", Director = "Yüksel Aksu", Platform = "Kanal D" }
            };

            Console.WriteLine("🎭 Welcome to Patikaflix! 🎭");
            Console.WriteLine("===========================");

            // Let's have some LINQ fun! 🎮

            Console.WriteLine("\n🎪 Comedy Show Starting!");
            var comedySeries = series
                .Where(s => s.Genre.Contains("Comedy"))
                .OrderBy(s => s.Name);

            foreach (var show in comedySeries)
            {
                Console.WriteLine($"🎯 {show.Name} - Director: {show.Director}");
            }

            // 🎨 Directors' statistics
            Console.WriteLine("\n🎬 Number of Series by Directors");
            var directors = series
                .GroupBy(d => d.Director)
                .Select(g => new { 
                    Director = g.Key, 
                    SeriesCount = g.Count(),
                    Series = string.Join(", ", g.Select(d => d.Name))
                });

            foreach (var director in directors)
            {
                Console.WriteLine($"👉 {director.Director}: directed {director.SeriesCount} series!");
                Console.WriteLine($"   💫 Series: {director.Series}");
            }

            // 📊 Platform analysis
            Console.WriteLine("\n📺 Which Platform Has Made More Series?");
            var platformAnalysis = series
                .GroupBy(d => d.Platform)
                .Select(g => new { Platform = g.Key, SeriesCount = g.Count() })
                .OrderByDescending(x => x.SeriesCount);

            foreach (var platform in platformAnalysis)
            {
                var emoji = platform.Platform == "Kanal D" ? "🥇" : 
                           platform.Platform == "Fox TV" ? "🦊" : "📺";
                Console.WriteLine($"{emoji} {platform.Platform}: {platform.SeriesCount} series");
            }
        }

        // 🆕 Method to add new series
        public static void AddNewSeries(List<TVSeries> series, TVSeries newSeries)
        {
            series.Add(newSeries);
            Console.WriteLine($"🎉 New series added: {newSeries.Name}");
        }

        // 🔍 Series search engine
        public static void SearchSeries(List<TVSeries> series, string searchTerm)
        {
            var foundSeries = series
                .Where(d => d.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (foundSeries.Any())
            {
                Console.WriteLine($"🔍 Found {foundSeries.Count} series for '{searchTerm}':");
                foreach (var show in foundSeries)
                {
                    Console.WriteLine($"✨ {show.Name} ({show.Year}) - {show.Genre}");
                }
            }
            else
            {
                Console.WriteLine($"😢 Oops! Couldn't find any series with '{searchTerm}'.");
            }
        }

        // 📅 Find most productive year
        public static void MostProductiveYear(List<TVSeries> series)
        {
            var mostProductiveYear = series
                .GroupBy(d => d.Year)
                .OrderByDescending(g => g.Count())
                .First();

            Console.WriteLine($"🏆 Most productive year: {mostProductiveYear.Key}");
            Console.WriteLine("📺 Series from that year:");
            foreach (var show in mostProductiveYear)
            {
                Console.WriteLine($"   ⭐ {show.Name}");
            }
        }
    }
}
```