using ShoppingPromoCore.Core.Promotion;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Core.RuleFinder
{
    /// <summary>
    /// New promotion rules can be added in the section or existing promotion
    /// can be changed in this portion which wil use the new logic if needed
    /// </summary>
    public class PromotionRuleFactory : IPromotionFactory
    {
        private readonly ILogger _logger;
        public PromotionRuleFactory(ILogger logger)
        {
            _logger = logger;
        }
        public IPromotionRule GetPromotionRule(PromotionType promoType)
        {
            IPromotionRule rule;
            switch (promoType)
            {
                case PromotionType.Fixed:
                    rule= new FixedPricePromotionRule(_logger);
                    break;
                case PromotionType.Percentage:
                    rule = new PercentagePricePromotionRule();
                    break;
                case PromotionType.Variable:
                    rule = new VariableDiscountPromotionRule();
                    break;
                default:
                    rule =  new FixedPricePromotionRule(_logger);
                    break;

            }

            return rule;

        }
    }
}