using System;
using System.Collections.Generic;
using System.Text;
using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IPromotionRuleRepo
    {
        List<PromotionDetails> GetPromotionRulesBySkuId(List<long> ids);
    }
    public interface ISKURepository
    {
        decimal GetSKUPrice(long skuid);
    }

    public interface IOrderCheckOutProcessor
    {

        decimal GetTotalOrderValue(Order order);
    }

    public interface IOrderDiscountCalculator
    {
        Order GetOrder();
        bool HasItemEligibleForPromotion();
        decimal GetTotalPrice();
        void DiscountOrderItems(List<OrderItem> orderItems, decimal priceWithDiscount);
        void AddOrderItem(IOrderItemDiscountCalculator item);
        void Initialize(Order order);
    }

    public interface IOrderItemDiscountCalculator
    {
        bool IsPromotionApplied();
        long GetItemSkuId();
        long GetQuantity();
        bool CanDiscountItems(int discountNeeded);
        void ApplyDiscountQuantity(int discountQuantity);
        decimal GetUnDiscountedPrice();
    }

    public interface IPromotionEngine
    {
        void ApplyPromotion(IOrderDiscountCalculator orderDiscountCalculator,
            List<IPromotionRule> rules);
    }

    public interface IPromotionRuleFinder
    {
        List<IPromotionRule> GetPromotionRules(Order order);
    }


    public interface IPromotionRule
    {
        void ApplyPromotion(Order order);
        bool IsPromotionActive();
        List<OrderItem> GetDiscountedItems();
        decimal GetDiscountedPrice();
    }




}
