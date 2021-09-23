using System.Collections.Generic;
using System.Text;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Core.Promotion
{
    public abstract class PromotionRule : IPromotionRule
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PromotionRuleItem> PromotionRuleItems { get; set; }

        protected bool IsActive { get; set; }

        public bool IsPromotionActive()
        {
            return IsActive;
        }
        public PromotionType Type { get; set; }

        public abstract void ApplyPromotion(Order order);

        protected decimal DisCountedPrice = 0;
        protected List<OrderItem> DiscountedItems;

        public List<OrderItem> GetDiscountedItems()
        {
            return DiscountedItems;
        }



        public decimal GetDiscountedPrice()
        {
            return DisCountedPrice;
        }
    }
}
