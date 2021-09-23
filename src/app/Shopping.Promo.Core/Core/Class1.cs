using System;
using System.Collections.Generic;
using System.Text;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Core
{

    public class PromotionRuleItem
    {
        public char SKUId { get; set; }
        public int Quantity { get; set; }

        
    }



    public abstract class PromotionRule : IPromotionRule
    {
        
    }


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
