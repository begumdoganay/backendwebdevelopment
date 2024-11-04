using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public class Author
    {
        public int AuthorId { get; set; }
        public required string Name { get; set; }
        public required string Nationality { get; set; }
        public int BirthYear { get; set; }
        public List<string> Awards { get; set; } = new List<string>();
    }

    public class Book
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public int AuthorId { get; set; }
        public required string Genre { get; set; }
        public int PublicationYear { get; set; }
        public required string Language { get; set; }
        public int PageCount { get; set; }
        public decimal Rating { get; set; }
    }

    static void Main()
    {
        // Extended sample dataset
        var authors = new List<Author>
        {
            new() {
                AuthorId = 1,
                Name = "Orhan Pamuk",
                Nationality = "Turkish",
                BirthYear = 1952,
                Awards = new List<string> { "Nobel Prize in Literature", "Peace Prize of the German Book Trade" }
            },
            new Author {
                AuthorId = 2,
                Name = "Elif Şafak",
                Nationality = "Turkish",
                BirthYear = 1971,
                Awards = new List<string> { "Ordre des Arts et des Lettres", "Chevalier of the Order of Arts and Letters" }
            },
            new Author {
                AuthorId = 3,
                Name = "Ahmet Ümit",
                Nationality = "Turkish",
                BirthYear = 1960,
                Awards = new List<string> { "Ankara Art Institution Novel Award" }
            }
        };

        var books = new List<Book>
        {
            new Book {
                BookId = 1,
                Title = "Kar",
                AuthorId = 1,
                Genre = "Literary Fiction",
                PublicationYear = 2002,
                Language = "Turkish",
                PageCount = 474,
                Rating = 4.2m
            },
            new Book {
                BookId = 2,
                Title = "Masumiyet Müzesi",
                AuthorId = 1,
                Genre = "Romance",
                PublicationYear = 2008,
                Language = "Turkish",
                PageCount = 592,
                Rating = 4.5m
            },
            new Book {
                BookId = 3,
                Title = "10 Minutes 38 Seconds in This Strange World",
                AuthorId = 2,
                Genre = "Contemporary Fiction",
                PublicationYear = 2019,
                Language = "English",
                PageCount = 312,
                Rating = 4.3m
            },
            new Book {
                BookId = 4,
                Title = "Beyoğlu Rapsodisi",
                AuthorId = 3,
                Genre = "Crime Fiction",
                PublicationYear = 2003,
                Language = "Turkish",
                PageCount = 384,
                Rating = 4.1m
            }
        };

        // 1. Advanced Query: Author Analytics
        Console.WriteLine("1. Author Analytics");
        Console.WriteLine("------------------");
        var authorAnalytics = authors
            .GroupJoin(books,
                author => author.AuthorId,
                book => book.AuthorId,
                (author, bookGroup) => new
                {
                    AuthorName = author.Name,
                    BookCount = bookGroup.Count(),
                    AverageRating = bookGroup.Any() ? Math.Round(bookGroup.Average(b => b.Rating), 2) : 0,
                    TotalPages = bookGroup.Sum(b => b.PageCount),
                    Awards = author.Awards.Count,
                    YearsActive = bookGroup.Any() ?
                        DateTime.Now.Year - bookGroup.Min(b => b.PublicationYear) : 0
                })
            .OrderByDescending(x => x.AverageRating);

        foreach (var analytics in authorAnalytics)
        {
            Console.WriteLine($"Author: {analytics.AuthorName}");
            Console.WriteLine($"Number of Books: {analytics.BookCount}");
            Console.WriteLine($"Average Rating: {analytics.AverageRating}");
            Console.WriteLine($"Total Pages Written: {analytics.TotalPages:N0}");
            Console.WriteLine($"Awards Won: {analytics.Awards}");
            Console.WriteLine($"Years Active: {analytics.YearsActive}");
            Console.WriteLine();
        }

        // 2. Genre Analysis
        Console.WriteLine("2. Genre Analysis");
        Console.WriteLine("----------------");
        var genreAnalysis = books
            .GroupBy(b => b.Genre)
            .Select(g => new
            {
                Genre = g.Key,
                BookCount = g.Count(),
                AverageRating = Math.Round(g.Average(b => b.Rating), 2),
                AuthorCount = g.Select(b => b.AuthorId).Distinct().Count(),
                AveragePages = (int)g.Average(b => b.PageCount)
            })
            .OrderByDescending(x => x.BookCount);

        foreach (var genre in genreAnalysis)
        {
            Console.WriteLine($"Genre: {genre.Genre}");
            Console.WriteLine($"Number of Books: {genre.BookCount}");
            Console.WriteLine($"Average Rating: {genre.AverageRating}");
            Console.WriteLine($"Number of Authors: {genre.AuthorCount}");
            Console.WriteLine($"Average Pages: {genre.AveragePages}");
            Console.WriteLine();
        }

        // 3. Language Distribution
        Console.WriteLine("3. Language Distribution");
        Console.WriteLine("----------------------");
        var languageStats = books
            .GroupBy(b => b.Language)
            .Select(g => new
            {
                Language = g.Key,
                BookCount = g.Count(),
                AuthorCount = g.Select(b => b.AuthorId).Distinct().Count(),
                AverageRating = Math.Round(g.Average(b => b.Rating), 2)
            })
            .OrderByDescending(x => x.BookCount);

        foreach (var lang in languageStats)
        {
            Console.WriteLine($"Language: {lang.Language}");
            Console.WriteLine($"Number of Books: {lang.BookCount}");
            Console.WriteLine($"Number of Authors: {lang.AuthorCount}");
            Console.WriteLine($"Average Rating: {lang.AverageRating}");
            Console.WriteLine();
        }
    }
}