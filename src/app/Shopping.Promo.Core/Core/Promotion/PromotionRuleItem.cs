using System.Linq;
using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Core.Promotion
{
    public class PromotionRuleItem
    {
        public char SKUId { get; set; }
        public int Quantity { get; set; }

        public int MaxNumberOfTimesApplicable(Order order)
        {
            var matchedOrderObj = order.Items.
                FirstOrDefault(orderItem => orderItem.SkuId == SKUId);
            if (matchedOrderObj == null)
            {
                return 0;
            }
            return matchedOrderObj.Quantity / Quantity;
        }
    }
}