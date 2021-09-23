using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IPromotionFactory
    {
        IPromotionRule GetPromotionRule(PromotionType promoType);
    }

    public interface IOrderItemDiscountCalculatorFactory
    {
        IOrderItemDiscountCalculator GetOrderItemDiscountCalculator(OrderItem orderItem, decimal unitPrice);
    }
    
}