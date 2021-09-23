using System.Collections.Generic;
using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IPromotionRuleRepo
    {
        List<PromotionDetails> GetPromotionRulesBySkuId(List<long> ids);
    }
}