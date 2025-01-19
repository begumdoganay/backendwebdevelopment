using BookStore_Web_Application.Core.Entities.Common;

namespace BookStore_Web_Application.Core.Entities
{
    public class BookCampaign : BaseEntity
    {
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int CampaignId { get; set; }
        public Campaign? Campaign { get; set; }

    
        public BookCampaign()
        {
            Book = null;
            Campaign = null;
        }
    }
}