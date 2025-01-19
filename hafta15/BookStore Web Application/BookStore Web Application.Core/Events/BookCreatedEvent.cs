using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Events
{
    public class BookCreatedEvent
    {
        public int BookId { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
