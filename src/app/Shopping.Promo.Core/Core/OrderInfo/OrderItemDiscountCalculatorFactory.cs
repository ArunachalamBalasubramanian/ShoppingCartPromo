using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Core.OrderInfo
{
    public class OrderItemDiscountCalculatorFactory : IOrderItemDiscountCalculatorFactory
    {
        public IOrderItemDiscountCalculator GetOrderItemDiscountCalculator(OrderItem orderItem, decimal unitPrice)
        {
            return new OrderItemDiscountCalculator(orderItem,  unitPrice);
        }
    }
}