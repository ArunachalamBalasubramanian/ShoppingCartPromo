using System.Collections.Generic;
using System.Data;
using System.Linq;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Core.OrderInfo
{
    public class OrderDiscountCalculator : IOrderDiscountCalculator
    {
        private Order _order;
        private decimal _cumulativePriceWithPromotion;
        private decimal _cumulativePriceWithOutPromotion;
        private readonly List<IOrderItemDiscountCalculator> _checkedOutItemDiscountCalculator;
       

        public OrderDiscountCalculator()
        {
            _checkedOutItemDiscountCalculator = new List<IOrderItemDiscountCalculator>();
        }


        public Order GetOrder()
        {
            return _order;
        }

        public void Initialize(Order order)
        {
            _checkedOutItemDiscountCalculator.Clear();
            _order = order;
        }




        public void AddOrderItem(IOrderItemDiscountCalculator item)
        {
            _checkedOutItemDiscountCalculator.Add(item);
        }

        private IOrderItemDiscountCalculator GetCheckedOutOrderItemBySkuId(char id)
        {
            return _checkedOutItemDiscountCalculator.FirstOrDefault(item =>
                item.GetItemSkuId() == id);
        }

        private bool IsDiscountValid(List<OrderItem> orderItems)
        {

            var isValid = false;
            foreach (var orderItem in orderItems)
            {
                isValid = CheckDiscount(orderItem);
            }
            return isValid;
        }

        private bool CheckDiscount(OrderItem item)
        {
            var processedItem = GetCheckedOutOrderItemBySkuId(item.SkuId);

            if (processedItem != null)
            {
                return processedItem.CanDiscountItems(item.Quantity);
            }

            return false;
        }

        public void DiscountOrderItems(List<OrderItem> orderItems, decimal priceWithDiscount)
        {
            if (IsDiscountValid(orderItems))
            {
                AddToPriceWithPromotion(priceWithDiscount);
                ApplyDiscountedQuantity(orderItems);
            }
        }
        private void AddToPriceWithPromotion(decimal discountedPrice)
        {
            _cumulativePriceWithPromotion = _cumulativePriceWithPromotion + discountedPrice;
        }

        private void ApplyDiscountedQuantity(List<OrderItem> orderItems)
        {
            foreach (var item in orderItems)
            {
                var processedItem = GetCheckedOutOrderItemBySkuId(item.SkuId);
                processedItem.ApplyDiscountQuantity(item.Quantity);
            }
        }

        public bool HasItemEligibleForPromotion()
        {
            return _checkedOutItemDiscountCalculator.
                FirstOrDefault(item => item.IsPromotionApplied() == false) != null;
        }

        public decimal GetTotalPrice()
        {
            _cumulativePriceWithOutPromotion = GetSkuPriceWithoutDiscount();
            return _cumulativePriceWithPromotion + _cumulativePriceWithOutPromotion;
        }

        private decimal GetSkuPriceWithoutDiscount()
        {
            decimal price = 0;
            foreach (var item in _checkedOutItemDiscountCalculator)
            {
                price = price + item.GetUnDiscountedPrice();
            }
            return price;
        }
    }
}
