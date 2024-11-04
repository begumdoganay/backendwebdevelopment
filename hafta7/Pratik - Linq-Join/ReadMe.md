# Week 7 - Advanced LINQ Operations in Library Analytics System

## Project Overview
This project demonstrates advanced LINQ operations in C# by implementing a comprehensive Library Analytics System. The system analyzes relationships between authors and their books, providing detailed statistics and insights using various LINQ join and grouping operations.

## Features

### 1. Enhanced Data Models

- **Author Model**
  - Basic information (ID, Name)
  - Biographical data (Nationality, Birth Year)
  - Professional achievements (Awards)

- **Book Model**
  - Basic information (ID, Title)
  - Publishing details (Publication Year, Language)
  - Technical details (Page Count)
  - Performance metrics (Rating)

### 2. Advanced Analytics

#### Author Analytics

- Number of books published
- Average book rating
- Total pages written
- Awards received
- Years active in writing

#### Genre Analysis

- Books per genre
- Average rating by genre
- Author distribution across genres
- Average page count by genre

#### Language Distribution

- Books per language
- Author count per language
- Average ratings by language

### 3. LINQ Operations Demonstrated

- Complex GroupJoin operations
- Multiple level grouping
- Aggregate functions
- Custom projections
- Advanced sorting

## Technical Implementation

### Key LINQ Features Used

```C#
// Example of Complex GroupJoin with Multiple Calculations
var authorAnalytics = authors
    .GroupJoin(books,
        author => author.AuthorId,
        book => book.AuthorId,
        (author, bookGroup) => new
        {
            AuthorName = author.Name,
            BookCount = bookGroup.Count(),
            AverageRating = bookGroup.Any() ? 
                Math.Round(bookGroup.Average(b => b.Rating), 2) : 0,
            // ... additional calculations
        });
```

## Code Organization

- Clear separation of data models
- Structured analytics sections
- Comprehensive output formatting
- Maintainable and extensible design

## Usage

1. Run the program to see analytics for:
   - Author performance metrics
   - Genre-based analysis
   - Language distribution statistics

## Future Enhancements

- Add more complex analytics
- Implement data visualization
- Add book series tracking
- Include publisher information
- Add temporal analysis features

## Learning Outcomes

- Advanced LINQ operations
- Complex data relationships
- Statistical analysis in C#
- Clean code practices
- Data model design

## Notes

- The system uses sample data for demonstration
- All calculations are performed in-memory using LINQ
- The output is formatted for easy reading and analysis

## Requirements

- .NET Core 3.1 or higher
- Basic understanding of LINQ and C#
- Visual Studio 2019 or higher (recommended)