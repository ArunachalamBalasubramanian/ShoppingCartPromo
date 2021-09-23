using ShoppingPromoCore.Core.Promotion;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Core.RuleFinder
{
    public class PromotionRuleFactory : IPromotionFactory
    {
        public IPromotionRule GetPromotionRule(PromotionType promoType)
        {
            IPromotionRule rule;
            switch (promoType)
            {
                case PromotionType.Fixed:
                    rule= new FixedPricePromotionRule();
                    break;
                case PromotionType.Percentage:
                    rule = new PercentagePricePromotionRule();
                    break;
                case PromotionType.Variable:
                    rule = new VariableDiscountPromotionRule();
                    break;
                default:
                    rule =  new FixedPricePromotionRule();
                    break;

            }

            return rule;

        }
    }
}