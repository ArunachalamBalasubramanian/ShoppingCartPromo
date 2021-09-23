using System;
using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Core.Promotion
{
    public class DiscountPricePromotionRule : PromotionRule
    {
        public decimal TotalDiscountInPrice { get; set; }

        public override void ApplyPromotion(Order order)
        {
            throw new NotImplementedException();
        }
    }
}