using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IOrderItemDiscountCalculatorFactory
    {
        IOrderItemDiscountCalculator GetOrderItemDiscountCalculator(OrderItem orderItem, decimal unitPrice);
    }
}