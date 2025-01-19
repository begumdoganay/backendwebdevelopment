using BookStore_Web_Application.Core.Entities.Common;
using Stripe;
using BookStore_Web_Application.Core.Enums;

namespace BookStore_Web_Application.Core.Entities
{
    public class Book : BaseAuditableEntity
    {
        public Book(string title, string isbn, decimal price)
        {
            Title = title;
            ISBN = isbn;
            Price = price;
        }

        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int FormatType { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<BookCampaign>? BookCampaigns { get; set; }
    }



    public class BookFormatType
    {
        public bool HasValue { get; set; }

        public static explicit operator int(BookFormatType v)
        {
            throw new NotImplementedException();
        }
    }
}
