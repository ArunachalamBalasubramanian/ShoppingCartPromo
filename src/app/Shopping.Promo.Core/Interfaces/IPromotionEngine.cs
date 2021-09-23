using System.Collections.Generic;

namespace ShoppingPromoCore.Interfaces
{
    public interface IPromotionEngine
    {
        void ApplyPromotion(IOrderDiscountCalculator orderDiscountCalculator,
            List<IPromotionRule> rules);
    }
}