using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using FakeItEasy;
using ShoppingPromoCore.Core.Promotion;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;
using Xunit;
using Xunit.Abstractions;
namespace Shopping.Promo.Core.Tests
{
    public class FixedPricePromotionRuleTests
    {
        private FixedPricePromotionRule _promotionRule;
        private readonly ILogger _logger;
        private IPromotionRuleItem _promotionRuleItem;
        private List<IPromotionRuleItem> _promotionRuleItemList;
        public FixedPricePromotionRuleTests()
        {
            _logger = FakeItEasy.A.Fake<ILogger>();
            _promotionRule = new FixedPricePromotionRule(_logger);
            _promotionRuleItem = FakeItEasy.A.Fake<IPromotionRuleItem>();
            _promotionRuleItemList = new List<IPromotionRuleItem>();


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
        public void Promotion_Item_Indiv_Minimum_Value_Return_Five()
        {
            _promotionRule.TotalPrice = 100;
            var order = GetOrder();
            AddNewOrderItem(order, 'A', 2);
            AddNewOrderItem(order, 'B', 2);



            
            _promotionRuleItemList.Add(_promotionRuleItem);
            _promotionRuleItemList.Add(_promotionRuleItem);
            _promotionRuleItemList.Add(_promotionRuleItem);
            _promotionRule.PromotionRuleItems = _promotionRuleItemList;

            A.CallTo(() => _promotionRuleItem.GetMaxNumberOfTimesPromotionApplicable(A<Order>._))
                .Returns(5).Once();


            A.CallTo(() => _promotionRuleItem.GetMaxNumberOfTimesPromotionApplicable(A<Order>._))
                .Returns(6).Once();
            A.CallTo(() => _promotionRuleItem.GetMaxNumberOfTimesPromotionApplicable(A<Order>._))
                .Returns(7).Once();

            _promotionRule.ApplyPromotion(order);

            var discountedItemsPrice = _promotionRule.GetDiscountedPrice();

            Assert.Equal(100*5, discountedItemsPrice);

        }

        [Fact]
        public void Promotion_Item_Indiv_Minimum_Value_Return_Zero()
        {
            _promotionRule.TotalPrice = 100;
            var order = GetOrder();
            AddNewOrderItem(order, 'A', 2);
            AddNewOrderItem(order, 'B', 2);




            _promotionRuleItemList.Add(_promotionRuleItem);
            _promotionRuleItemList.Add(_promotionRuleItem);
            _promotionRuleItemList.Add(_promotionRuleItem);
            _promotionRule.PromotionRuleItems = _promotionRuleItemList;

            A.CallTo(() => _promotionRuleItem.GetMaxNumberOfTimesPromotionApplicable(A<Order>._))
                .Returns(5).Once();
            A.CallTo(() => _promotionRuleItem.GetMaxNumberOfTimesPromotionApplicable(A<Order>._))
                .Returns(0).Once();
            A.CallTo(() => _promotionRuleItem.GetMaxNumberOfTimesPromotionApplicable(A<Order>._))
                .Returns(7).Once();

            _promotionRule.ApplyPromotion(order);

            var discountedItemsPrice = _promotionRule.GetDiscountedPrice();

            Assert.Equal(100 * 0, discountedItemsPrice);

        }
    }
}