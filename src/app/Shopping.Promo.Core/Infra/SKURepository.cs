using System;
using System.Text;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Infra
{
    public class SKURepository : ISKURepository
    {
        public decimal GetSKUPrice(long skuid)
        {
            return 1;
        }
    }
}
