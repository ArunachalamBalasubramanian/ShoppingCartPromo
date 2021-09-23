using System.Linq;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Core.Promotion
{

    
    public class PromotionRuleItem : IPromotionRuleItem
    {
        public char SkuId { get; set; }
        public int Quantity { get; set; }

        public int GetMaxNumberOfTimesPromotionApplicable(Order order)
        {
            var matchedOrderObj = order.Items.
                FirstOrDefault(orderItem => orderItem.SkuId == SkuId);
            if (matchedOrderObj == null)
            {
                return 0;
            }
            return matchedOrderObj.Quantity / Quantity;
        }
    }
}