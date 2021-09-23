using System;
using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Core.Promotion
{
    public class VariableDiscountPromotionRule : PromotionRule
    {

        public decimal TotalVariableDiscountInPrice { get; set; }


        public override void ApplyPromotion(Order order)
        {
            throw new NotImplementedException();
        }
    }
}