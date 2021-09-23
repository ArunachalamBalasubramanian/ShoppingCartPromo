using System;
using System.Collections.Generic;
using System.Text;
using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IPromotionRule
    {
        void ApplyPromotion(Order order);
        bool IsPromotionActive();
        List<OrderItem> GetDiscountedItems();
        decimal GetDiscountedPrice();
    }
}
