using BookStore_Web_Application.Core.Entities;


namespace BookStore_Web_Application.Core.Dtos.Books
{
    public class UpdateBookDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public BookFormatType? FormatType { get; set; }
        public int CategoryId { get; set; }
    }
}
