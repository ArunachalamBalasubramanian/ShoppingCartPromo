using System;
using System.Text;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Infra
{
    /// <summary>
    /// gets the sku details from persistent store.
    /// Can add multiple methods to add, update, delete and filter
    /// by needed conditions
    /// </summary>
    public class SkuRepository : ISkuRepository
    {
        public decimal GetSkuPrice(char skuId)
        {
            return 1;
        }
    }
}
