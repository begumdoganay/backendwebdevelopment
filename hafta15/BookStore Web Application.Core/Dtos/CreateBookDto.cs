using BookStore_Web_Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Dtos
{
    public class CreateBookDto
    {
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public BookFormatType? FormatType { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
