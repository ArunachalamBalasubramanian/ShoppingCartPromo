using System;
using System.Collections.Generic;
using System.Text;
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
    public class SKURepository : ISKURepository
    {
        public decimal GetSKUPrice(long skuid)
        {
            return 1;
        }
    }
}
