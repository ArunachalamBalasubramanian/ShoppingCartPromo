using System;
using System.Collections.Generic;
using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Core.Promotion
{
    public class FixedPricePromotionRule : PromotionRule
    {
        // 3A + 2b = 350
        public decimal TotalPrice { get; set; }

        private int _numberOfTimesToApplyThePromotion;


        private void Reset()
        {
            _numberOfTimesToApplyThePromotion = Int32.MaxValue;
            DisCountedPrice = 0;
            DiscountedItems = new List<OrderItem>();
        }


        public override void ApplyPromotion(Order order)
        {
            Reset();
            GetPromotionCount(order);
            if (IsPromotionApplicable())
            {
                ApplyDiscount(order);
            }
        }


        private bool IsPromotionApplicable()
        {
            return _numberOfTimesToApplyThePromotion > 0;
        }

        private void ContributeToPromotionCount(int ruleItemCount)
        {
            if (ruleItemCount < _numberOfTimesToApplyThePromotion)
            {
                _numberOfTimesToApplyThePromotion = ruleItemCount;
            }
        }

        private void ApplyDiscount(Order order)
        {
            // Rule 3A+2B

            //order --> 7A + 2B

            DisCountedPrice = _numberOfTimesToApplyThePromotion * TotalPrice;

            List<OrderItem> discountedItems = new List<OrderItem>();
            foreach (var ruleItem in PromotionRuleItems)
            {

                discountedItems.Add(new OrderItem
                {
                    SkuId = ruleItem.SKUId,
                    Quantity = (ruleItem.Quantity * _numberOfTimesToApplyThePromotion)
                });
            }

        }

        private void GetPromotionCount(Order order)
        {
            // 3A 2B - Rule
            // Incoming 6A 5B

            foreach (var ruleItem in PromotionRuleItems)
            {
                if (IsPromotionApplicable())
                {
                    var promotionCountpossible = ruleItem.MaxNumberOfTimesApplicable(order);
                    ContributeToPromotionCount(promotionCountpossible);
                }
            }


        }
    }
}