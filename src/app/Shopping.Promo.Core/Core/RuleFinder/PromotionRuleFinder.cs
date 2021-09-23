using System;
using System.Collections.Generic;
using System.Text;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Core.RuleFinder
{
    public class PromotionRuleFinder : IPromotionRuleFinder
    {
        public PromotionRuleFinder(IPromotionRuleRepo promoRule)
        {

        }

        public List<IPromotionRule> GetPromotionRules(Order order)
        {
            return null;
        }
    }
}
