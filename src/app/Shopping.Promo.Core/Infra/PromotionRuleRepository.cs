using System.Collections.Generic;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Infra
{
    /// <summary>
    /// gets the saved or configured promotion details from a store
    /// </summary>
    public class PromotionRuleRepository : IPromotionRuleRepo
    {
        public List<PromotionDetails> GetPromotionRulesBySkuId(List<long> ids)
        {
            return new List<PromotionDetails>();
        }
    }
}