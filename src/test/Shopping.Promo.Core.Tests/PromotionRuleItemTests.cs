using System.Collections.Generic;
using Xunit;
using FakeItEasy;
using ShoppingPromoCore.Core.Promotion;
using ShoppingPromoCore.Entities;

namespace Shopping.Promo.Core.Tests
{
    public class PromotionRuleItemTests
    {

        public PromotionRuleItemTests()
        {
                
        }

        private PromotionRuleItem GetPromotionRuleItem(char skuId, int quantity)
        {
            PromotionRuleItem item = new PromotionRuleItem();
            item.SkuId = skuId;
            item.Quantity = quantity;
            return item;
        }

        private Order GetOrder()
        {
            var order = new Order { Id = 1, Items = new List<OrderItem>() };

            return order;
        }

        private void AddNewOrderItem(Order order, char skuId, int quantity )
        {

            var orderItem = new OrderItem {Quantity = quantity, SkuId = skuId};
            order.Items.Add(orderItem);
        }

        [Fact]
        public void GetMaxNumberOfTimesPromotionApplicable_Order_No_Items_Returns_Zero()
        {
            var item = GetPromotionRuleItem('A', 2);
            var order = GetOrder();
            

            var value = item.GetMaxNumberOfTimesPromotionApplicable(order);

            Assert.Equal(0, value);
        }

        [Fact]
        public void GetMaxNumberOfTimesPromotionApplicable_Order_Matching_Items_Returns_1()
        {
            var item = GetPromotionRuleItem('A', 2);
            var order = GetOrder();
            AddNewOrderItem(order, 'A', 2);

            var value = item.GetMaxNumberOfTimesPromotionApplicable(order);

            Assert.Equal(1, value);
        }

        [Fact]
         public void GetMaxNumberOfTimesPromotionApplicable_Order_Matching_Items_Returns_3()
        
        {
            var item = GetPromotionRuleItem('A', 2);
            var order = GetOrder();
            AddNewOrderItem(order, 'A', 6);

            var value = item.GetMaxNumberOfTimesPromotionApplicable(order);

            Assert.Equal(3, value);
        }

         [Fact]
         public void GetMaxNumberOfTimesPromotionApplicable_Order_No_Matching_Items_Returns_0()

         {
             var item = GetPromotionRuleItem('A', 2);
             var order = GetOrder();
             AddNewOrderItem(order, 'B', 6);
             AddNewOrderItem(order, 'C', 2);
             AddNewOrderItem(order, 'D', 2);

            var value = item.GetMaxNumberOfTimesPromotionApplicable(order);

             Assert.Equal(0, value);
         }
         [Fact]
         public void GetMaxNumberOfTimesPromotionApplicable_Order_Matching_Items_Odd_Number_Returns_0()

         {
             var item = GetPromotionRuleItem('A', 2);
             var order = GetOrder();
             AddNewOrderItem(order, 'B', 6);
             AddNewOrderItem(order, 'C', 2);
             AddNewOrderItem(order, 'D', 2);
             AddNewOrderItem(order, 'A', 7);

            var value = item.GetMaxNumberOfTimesPromotionApplicable(order);

             Assert.Equal(3, value);
         }
    }
}