using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingPromoCore.Entities
{
    public class Order
    {
        public long Id { get; set; }

        public List<OrderItem> Items { get; set; }

    }

    public class OrderItem
    {
        public char SkuId { get; set; }
        public int Quantity { get; set; }

    }

    public class SKU
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public enum PromotionType
    {
        None = 0,
        Fixed = 1,
        Percentage = 2
    }



    public class PromotionDetails
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PromotionRuleDetails> PromotionRuleDetails { get; set; }

    }



    public class PromotionRuleDetails
    {
        public char SKUId { get; set; }
        public int Quantity { get; set; }
    }
}
