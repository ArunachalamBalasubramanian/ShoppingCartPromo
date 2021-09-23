using System;

namespace ShoppingPromoCore.Interfaces
{
    public interface ILogger
    {
        void Log(string message);
        void Log(Exception ex, string message);
    }
}