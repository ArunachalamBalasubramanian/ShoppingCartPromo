using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IPromotionFactory
    {
        IPromotionRule GetPromotionRule(PromotionType promoType);
    }
}