namespace ShoppingPromoCore.Interfaces
{
    public interface ISkuRepository
    {
        decimal GetSKUPrice(long skuid);
    }
}