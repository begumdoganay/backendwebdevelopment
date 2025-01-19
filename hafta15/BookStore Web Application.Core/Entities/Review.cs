using BookStore_Web_Application.Core.Entities.Common;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Azure.Documents;


namespace BookStore_Web_Application.Core.Entities
{
    public class Review : BaseAuditableEntity
    {
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
