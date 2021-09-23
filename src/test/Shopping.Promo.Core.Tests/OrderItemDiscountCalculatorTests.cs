using System.Collections.Generic;
using ShoppingPromoCore.Core.OrderInfo;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;
using Xunit;

namespace Shopping.Promo.Core.Tests
{
    public class OrderDiscountCalculatorTests
    {

        private readonly List<IOrderItemDiscountCalculator> _checkedOutItemDiscountCalculator;
        private OrderDiscountCalculator _orderDiscCalculator;
        public OrderDiscountCalculatorTests()
        {
            _checkedOutItemDiscountCalculator = FakeItEasy.A.Fake<List<IOrderItemDiscountCalculator>>();
            _orderDiscCalculator = new OrderDiscountCalculator();
        }

        private Order GetOrder()
        {
            var order = new Order { Id = 1, Items = new List<OrderItem>() };
            return order;
        }

        private void AddNewOrderItem(Order order, char skuId, int quantity)
        {
            var orderItem = new OrderItem { Quantity = quantity, SkuId = skuId };
            order.Items.Add(orderItem);
        }

        [Fact]
        public void OrderDiscountCalculator_Initialize_Test()
        {
            _orderDiscCalculator.Initialize(GetOrder());

            var ord = _orderDiscCalculator.GetOrder();

            Assert.Equal(0, ord.Items.Count);
        }


        [Fact]
        public void OrderDiscountCalculator_Initialize_Order_Two_Items_Return_2()
        {
            var order = GetOrder();
            AddNewOrderItem(order, 'A', 2);
            AddNewOrderItem(order, 'B', 2);
            _orderDiscCalculator.Initialize(order);
            

            var ord = _orderDiscCalculator.GetOrder();

            Assert.Equal(2, ord.Items.Count);
        }
    }
}