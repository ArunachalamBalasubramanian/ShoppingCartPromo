using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IPromotionRuleItem
    {
        public char SkuId { get; set; }
        public int Quantity { get; set; }
        int GetMaxNumberOfTimesPromotionApplicable(Order order);
    }
}