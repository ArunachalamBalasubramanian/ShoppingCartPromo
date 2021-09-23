namespace ShoppingPromoCore.Interfaces
{
    public interface IOrderItemDiscountCalculator
    {
        bool IsPromotionApplied();
        long GetItemSkuId();
        long GetQuantity();
        bool CanDiscountItems(int discountNeeded);
        void ApplyDiscountQuantity(int discountQuantity);
        decimal GetUnDiscountedPrice();
    }
}