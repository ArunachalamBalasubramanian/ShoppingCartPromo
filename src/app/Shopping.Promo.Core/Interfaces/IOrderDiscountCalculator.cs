using System.Collections.Generic;
using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IOrderDiscountCalculator
    {
        Order GetOrder();
        bool HasItemEligibleForPromotion();
        decimal GetTotalPrice();
        void DiscountOrderItems(List<OrderItem> orderItems, decimal priceWithDiscount);
        void AddOrderItem(IOrderItemDiscountCalculator item);
        void Initialize(Order order);
    }
}