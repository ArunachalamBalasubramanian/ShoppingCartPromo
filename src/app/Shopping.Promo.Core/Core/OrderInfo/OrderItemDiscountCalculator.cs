using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Core.OrderInfo
{
    public class OrderItemDiscountCalculator : IOrderItemDiscountCalculator
    {
        private OrderItem _orderItem;
        private decimal _unitPrice;
        private decimal _actualTotalPrice;
        private int _discountedQuantity;
        private bool _isPromotionApplied;

        public long GetItemSkuId()
        {
            return _orderItem.SkuId;
        }

        public bool IsPromotionApplied()
        {
            return _isPromotionApplied;
        }

        public OrderItemDiscountCalculator(OrderItem item, decimal unitPrice)
        {
            _orderItem = item;
            _unitPrice = unitPrice;
            _actualTotalPrice = _orderItem.Quantity * _unitPrice;
        }

        public long GetQuantity()
        {
            return _orderItem.SkuId;
        }
        public decimal GetUnDiscountedPrice()
        {
            return (_orderItem.Quantity - _discountedQuantity) * _unitPrice;
        }


        public bool CanDiscountItems(int discountNeeded)
        {
            if ((_orderItem.Quantity - _discountedQuantity) - discountNeeded > 0)
            {
                return true;
            }
            return false;
        }

        public void ApplyDiscountQuantity(int discountQuantity)
        {
            _discountedQuantity = _discountedQuantity + discountQuantity;
            _isPromotionApplied = true;
        }




    }
}