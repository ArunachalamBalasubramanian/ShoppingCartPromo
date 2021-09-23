using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IPromotionRuleItem
    {
        int MaxNumberOfTimesApplicable(Order order);
    }
}