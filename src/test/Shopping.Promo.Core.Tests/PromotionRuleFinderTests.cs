using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Components.DictionaryAdapter;
using FakeItEasy;
using ShoppingPromoCore.Core.RuleFinder;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;
using Xunit;

namespace Shopping.Promo.Core.Tests
{
    public class PromotionRuleFinderTests
    {

        private readonly ILogger _logger;
        private readonly IPromotionRuleRepo _promoRuleRepo;
        private readonly IPromotionFactory _promotionFactory;

        private readonly PromotionRuleFinder _promoRuleFinder;

        public PromotionRuleFinderTests()
        {
            _logger = FakeItEasy.A.Fake<ILogger>();
            _promoRuleRepo = FakeItEasy.A.Fake<IPromotionRuleRepo>();
            _promotionFactory = FakeItEasy.A.Fake<IPromotionFactory>();
            _promoRuleFinder = new PromotionRuleFinder(_promoRuleRepo, _promotionFactory, _logger);
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
        public void GetPromotionRulesBySkuId_Returns_Empty_Rule_List()
        {

            var order = GetOrder();
            AddNewOrderItem(order, 'A', 2);
            AddNewOrderItem(order, 'B', 2);
            AddNewOrderItem(order, 'C', 2);
            AddNewOrderItem(order, 'D', 2);
            
           
          
           
            A.CallTo(() => _promoRuleRepo.GetPromotionRulesBySkuId(A<List<char>>._))
                .Returns(new EditableList<PromotionDetails>());
            var rules = _promoRuleFinder.GetPromotionRules(order);

            Assert.Equal(0, rules.Count);






        }

        [Fact]
        public void GetPromotionRulesBySkuId_Returns_TwoRule_List()
        {

            var order = GetOrder();
           

            var lst = new List<PromotionDetails>();

            lst.Add(new PromotionDetails{ PromotionRuleDetails = new EditableList<PromotionRuleDetails>()} );
            lst.Add(new PromotionDetails { PromotionRuleDetails = new EditableList<PromotionRuleDetails>() });
           

            A.CallTo(() => _promoRuleRepo.GetPromotionRulesBySkuId(A<List<char>>._))
                .Returns(lst);
            var rules = _promoRuleFinder.GetPromotionRules(order);

            Assert.Equal(2, rules.Count);
        }




    
    }
}