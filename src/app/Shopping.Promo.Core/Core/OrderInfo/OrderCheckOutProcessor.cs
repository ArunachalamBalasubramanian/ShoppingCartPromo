using System.Collections.Generic;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Core.OrderInfo
{
    public class OrderCheckOutProcessor : IOrderCheckOutProcessor 
    {
        private readonly ISkuRepository _skuRepo;
        private readonly IPromotionRuleFinder _ruleFinder;
        private readonly IPromotionEngine _promotionEngine;
        private readonly IOrderDiscountCalculator _orderDiscountCalculator;
        public OrderCheckOutProcessor(ISkuRepository skuRepo,
            IPromotionRuleFinder promotionRuleFinder,
            IPromotionEngine promotionEngine,
            IOrderDiscountCalculator orderDiscountCalculator
        )
        {
            _skuRepo = skuRepo;
            _ruleFinder = promotionRuleFinder;
            _promotionEngine = promotionEngine;
            _orderDiscountCalculator = orderDiscountCalculator;


        }

        public decimal GetTotalOrderValue(Order order)
        {
            InitializeDiscountCalculator(order);
            List<IPromotionRule> rules = _ruleFinder.GetPromotionRules(order);
            _promotionEngine.ApplyPromotion(_orderDiscountCalculator, rules);
            return _orderDiscountCalculator.GetTotalPrice();

        }





        private IOrderDiscountCalculator InitializeDiscountCalculator(Order order)
        {
            _orderDiscountCalculator.Initialize(order);
            foreach (var item in order.Items)
            {
                var unitPrice = _skuRepo.GetSkuPrice(item.SkuId);
                _orderDiscountCalculator.AddOrderItem(new OrderItemDiscountCalculator(item, unitPrice));
            }

            return _orderDiscountCalculator;
        }


    }
}