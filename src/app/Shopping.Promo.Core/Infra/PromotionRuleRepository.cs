using System.Collections.Generic;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Infra
{
    public class PromotionRuleRepository : IPromotionRuleRepo
    {
        public List<PromotionDetails> GetPromotionRulesBySkuId(List<long> ids)
        {
            return new List<PromotionDetails>();
        }
    }
}