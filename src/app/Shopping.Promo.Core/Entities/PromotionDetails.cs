using System.Collections.Generic;

namespace ShoppingPromoCore.Entities
{
    public class PromotionDetails
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PromotionRuleDetails> PromotionRuleDetails { get; set; }
        public PromotionType PromoType { get; set; }

    }
}