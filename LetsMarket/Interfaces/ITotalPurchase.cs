using LetsMarket.Logic;

namespace LetsMarket.Interfaces
{
    public interface ITotalPurchase
    {
        void TotalOfPurchase(decimal total, Product closeSale, Product product);
    }
}
