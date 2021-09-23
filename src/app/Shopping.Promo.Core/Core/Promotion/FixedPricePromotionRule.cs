using System;
using System.Collections.Generic;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Core.Promotion
{
    public class FixedPricePromotionRule : PromotionRule
    {
        public decimal TotalPrice { get; set; }

        private int _numberOfTimesToApplyThePromotion;
        private readonly ILogger _logger;

        public FixedPricePromotionRule(ILogger logger)
        {
            _logger = logger;
        }
        private void Reset()
        {
            _numberOfTimesToApplyThePromotion = Int32.MaxValue;
            DisCountedPrice = 0;
            DiscountedItems = new List<OrderItem>();
        }


        public override void ApplyPromotion(Order order)
        {
            Reset();
            UpdatePromotionCount(order);
            if (IsPromotionApplicable())
            {
                CalculateDiscount(order);
            }
        }


        private bool IsPromotionApplicable()
        {
            return _numberOfTimesToApplyThePromotion > 0;
        }

        private bool IsDefaultMatchingValue()
        {
            return _numberOfTimesToApplyThePromotion == Int32.MaxValue;
        }

        private void ContributeToPromotionCount(int ruleItemCount)
        {

            if (ruleItemCount < _numberOfTimesToApplyThePromotion)
            {
                _numberOfTimesToApplyThePromotion = ruleItemCount;
            }
        }

        private void CalculateDiscount(Order order)
        {
            if (!IsDefaultMatchingValue())
            {
                DisCountedPrice = _numberOfTimesToApplyThePromotion * TotalPrice;


                foreach (var ruleItem in PromotionRuleItems)
                {

                    DiscountedItems.Add(new OrderItem
                    {
                        SkuId = ruleItem.SkuId,
                        Quantity = (ruleItem.Quantity * _numberOfTimesToApplyThePromotion)
                    });
                }
            }

        }

        private void UpdatePromotionCount(Order order)
        {
            foreach (var ruleItem in PromotionRuleItems)
            {
                if (IsPromotionApplicable())
                {
                    var possiblePromotionCount = ruleItem.GetMaxNumberOfTimesPromotionApplicable(order);
                    ContributeToPromotionCount(possiblePromotionCount);
                }
            }
        }
    }
}