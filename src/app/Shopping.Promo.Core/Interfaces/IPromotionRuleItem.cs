using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IPromotionRuleItem
    {
        int GetMaxNumberOfTimesPromotionApplicable(Order order);
    }
}