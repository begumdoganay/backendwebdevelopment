using BookStore_Web_Application.Core.Entities.Common;
using BookStore_Web_Application.Core.Enums;  // Kendi enum'ımızı kullanmak için

namespace BookStore_Web_Application.Core.Entities
{
    public class Campaign : BaseAuditableEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CampaignType Type { get; set; }  // MailChimp'ten değil, kendi enum'ımızı kullanıyoruz
        public decimal DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<BookCampaign>? BookCampaigns { get; set; } = new List<BookCampaign>();

    }
}
