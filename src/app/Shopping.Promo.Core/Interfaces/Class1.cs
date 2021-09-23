using System;
using System.Collections.Generic;
using System.Text;
using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IPromotionRuleRepo
    {
        List<PromotionDetails> GetPromotionRulesBySkuId(List<long> ids);
    }
    public interface ISKURepository
    {
        decimal GetSKUPrice(long skuid);
    }
}
