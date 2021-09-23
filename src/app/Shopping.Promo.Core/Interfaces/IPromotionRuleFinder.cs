using System.Collections.Generic;
using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IPromotionRuleFinder
    {
        List<IPromotionRule> GetPromotionRules(Order order);
    }
}