using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Events
{
    public class BookStockUpdatedEvent
    {
        public int BookId { get; set; }
        public int OldStock { get; set; }
        public int NewStock { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
