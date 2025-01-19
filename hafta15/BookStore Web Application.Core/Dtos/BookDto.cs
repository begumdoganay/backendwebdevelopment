using BookStore_Web_Application.Core.Entities;


namespace BookStore_Web_Application.Core.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public BookFormatType? FormatType { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public double AverageRating { get; set; }
    }

}
