using System;
using System.Collections.Generic;
using System.Text;
using ShoppingPromoCore.Core.Promotion;
using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IPromotionRule
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PromotionRuleItem> PromotionRuleItems { get; set; }

        void ApplyPromotion(Order order);
        bool IsPromotionActive();
        List<OrderItem> GetDiscountedItems();
        decimal GetDiscountedPrice();
    }
}
