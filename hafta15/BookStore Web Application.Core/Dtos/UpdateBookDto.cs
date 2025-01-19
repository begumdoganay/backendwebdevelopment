

namespace BookStore_Web_Application.Core.Dtos
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
