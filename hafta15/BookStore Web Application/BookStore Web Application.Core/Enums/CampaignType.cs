using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Enums
{
    public enum CampaignType
    {
        None,
        Percentage = 1,
        FixedAmount = 2,
        BuyOneGetOne = 3,
        SeasonalDiscount = 4,
        NewUserDiscount = 5,
        BulkPurchase = 6
    }
}