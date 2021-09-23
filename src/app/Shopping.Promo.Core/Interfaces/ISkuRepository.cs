namespace ShoppingPromoCore.Interfaces
{
    public interface ISkuRepository
    {
        decimal GetSkuPrice(char skuId);
    }
}