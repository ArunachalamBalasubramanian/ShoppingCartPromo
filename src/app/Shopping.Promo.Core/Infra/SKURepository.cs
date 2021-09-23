using System;
using System.Text;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Infra
{
    public class SKURepository : ISkuRepository
    {
        public decimal GetSKUPrice(long skuid)
        {
            return 1;
        }
    }
}
