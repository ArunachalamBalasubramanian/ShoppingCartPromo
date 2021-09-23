using System;
using System.Collections.Generic;
using FakeItEasy;
using ShoppingPromoCore.Core.Promotion;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;
using Xunit;

namespace Shopping.Promo.Core.Tests
{
    public class PromotionEngineTests
    {
        private PromotionEngine _engine;
        private IOrderDiscountCalculator _orderDiscCaculator;
        private IPromotionRule _promotionRule;
        private List<IPromotionRule> _promotionRuleList;

        public PromotionEngineTests()
        {
            _engine = new PromotionEngine();
            _promotionRule = FakeItEasy.A.Fake<IPromotionRule>();
            _promotionRuleList = new List<IPromotionRule>();
            _orderDiscCaculator = FakeItEasy.A.Fake<IOrderDiscountCalculator>();

        }
        [Fact]
        public void Track_Calls_With_Two_Rules()
        {
            _promotionRuleList.Add(_promotionRule);
            _promotionRuleList.Add(_promotionRule);
            A.CallTo(() => _orderDiscCaculator.HasItemEligibleForPromotion())
                .Returns(true);

            
            _engine.ApplyPromotion(_orderDiscCaculator, _promotionRuleList);


            A.CallTo(() => _promotionRule.ApplyPromotion(A<Order>._))
                .MustHaveHappened(2, Times.Exactly);
            A.CallTo(() => _orderDiscCaculator.DiscountOrderItems(A<List<OrderItem>>._,
                A<decimal>._)).MustHaveHappened(2, Times.Exactly);


        }

        [Fact]
        public void Track_Calls_With_Two_Rules_OneEligible_Condition()
        {
            _promotionRuleList.Add(_promotionRule);
            _promotionRuleList.Add(_promotionRule);
           


            A.CallTo(() => _orderDiscCaculator.HasItemEligibleForPromotion())
                .Returns(true).Once();

            A.CallTo(() => _orderDiscCaculator.HasItemEligibleForPromotion())
                .Returns(false).Once();

            _engine.ApplyPromotion(_orderDiscCaculator, _promotionRuleList);

            A.CallTo(() => _promotionRule.ApplyPromotion(A<Order>._))
                .MustHaveHappened(1, Times.Exactly);
            A.CallTo(() => _orderDiscCaculator.DiscountOrderItems(A<List<OrderItem>>._,
                A<decimal>._)).MustHaveHappened(1, Times.Exactly);


        }
    }
}
