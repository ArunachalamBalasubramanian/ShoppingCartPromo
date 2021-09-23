using System.Collections.Generic;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Core.Promotion
{
    public class PromotionEngine : IPromotionEngine
    {
        public void ApplyPromotion(IOrderDiscountCalculator orderDiscCalculator,
            List<IPromotionRule> rules)
        {
            foreach (var rule in rules)
            {
                if (orderDiscCalculator.HasItemEligibleForPromotion())
                {
                    rule.ApplyPromotion(orderDiscCalculator.GetOrder());

                    orderDiscCalculator.DiscountOrderItems(rule.GetDiscountedItems(),
                        rule.GetDiscountedPrice());

                }
            }

        }
    }
}