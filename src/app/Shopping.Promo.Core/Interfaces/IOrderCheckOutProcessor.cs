using ShoppingPromoCore.Entities;

namespace ShoppingPromoCore.Interfaces
{
    public interface IOrderCheckOutProcessor
    {

        decimal GetTotalOrderValue(Order order);
    }
}