using System.Collections.Generic;

namespace ShoppingPromoCore.Entities
{
    public class Order
    {
        public long Id { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}