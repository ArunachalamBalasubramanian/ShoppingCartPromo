
using System.Collections.Generic;
using FakeItEasy;
using ShoppingPromoCore.Core.OrderInfo;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;
using Xunit;
using Xunit.Abstractions;
namespace Shopping.Promo.Core.Tests
{
    public class OrderCheckOutProcessorTests
    {
        private readonly ISkuRepository _skuRepo;
        private readonly IPromotionRuleFinder _ruleFinder;
        private readonly IPromotionEngine _promotionEngine;
        private readonly IOrderDiscountCalculator _orderDiscountCalculator;
        private readonly IOrderItemDiscountCalculatorFactory _orderItemDiscountCalculatorFactory;
        private readonly ILogger _logger;

        private readonly OrderCheckOutProcessor _orderProcessor;

        public OrderCheckOutProcessorTests()
        {
            _logger = FakeItEasy.A.Fake<ILogger>();
            _skuRepo = FakeItEasy.A.Fake<ISkuRepository>();
            _ruleFinder = FakeItEasy.A.Fake<IPromotionRuleFinder>();
            _promotionEngine = FakeItEasy.A.Fake<IPromotionEngine>();
            _orderDiscountCalculator = FakeItEasy.A.Fake<IOrderDiscountCalculator>();
            _orderItemDiscountCalculatorFactory = FakeItEasy.A.Fake<IOrderItemDiscountCalculatorFactory>();
            _orderProcessor = new OrderCheckOutProcessor(_skuRepo, _ruleFinder,
                _promotionEngine, _orderDiscountCalculator, _orderItemDiscountCalculatorFactory, _logger);
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
       
        public void OrderDiscountCalculator_With_One_Order_Item_Track_Calls()
        {
            var order = GetOrder();
            AddNewOrderItem(order, 'A', 2);
            

           var value= _orderProcessor.GetTotalOrderValue(order);


           A.CallTo(() => _orderDiscountCalculator.Initialize(A<Order>._)).MustHaveHappened();
           A.CallTo(() => _ruleFinder.GetPromotionRules(A<Order>._)).MustHaveHappened();
           A.CallTo(() => _promotionEngine.ApplyPromotion(A<IOrderDiscountCalculator>._,
               A<List<IPromotionRule>>._)).MustHaveHappened();
           A.CallTo(() => _orderDiscountCalculator.GetTotalPrice()).MustHaveHappened();
           A.CallTo(() => _skuRepo.GetSkuPrice(A<char>._)).MustHaveHappened(1, Times.Exactly);
           A.CallTo(() => _orderDiscountCalculator.AddOrderItem(A<IOrderItemDiscountCalculator>._))
               .MustHaveHappened(1, Times.Exactly);

           

        }


        [Fact]

        public void OrderDiscountCalculator_With_FIve_Order_Items_Track_MethodCalls()
        {
            var order = GetOrder();
            AddNewOrderItem(order, 'A', 2);
            AddNewOrderItem(order, 'B', 2);
            AddNewOrderItem(order, 'C', 2);
            AddNewOrderItem(order, 'D', 2);
            AddNewOrderItem(order, 'E', 2);

            var value = _orderProcessor.GetTotalOrderValue(order);


            A.CallTo(() => _orderDiscountCalculator.Initialize(A<Order>._)).MustHaveHappened();
            A.CallTo(() => _ruleFinder.GetPromotionRules(A<Order>._)).MustHaveHappened();
            A.CallTo(() => _promotionEngine.ApplyPromotion(A<IOrderDiscountCalculator>._,
                A<List<IPromotionRule>>._)).MustHaveHappened();
            A.CallTo(() => _orderDiscountCalculator.GetTotalPrice()).MustHaveHappened();
            A.CallTo(() => _skuRepo.GetSkuPrice(A<char>._)).MustHaveHappened(5, Times.Exactly);
            A.CallTo(() => _orderDiscountCalculator.AddOrderItem(A<IOrderItemDiscountCalculator>._))
                .MustHaveHappened(5, Times.Exactly);



        }

    }
}