using LetsMarket.Logic;

namespace LetsMarket.Interfaces
{
    public interface IItemCanceller
    {
        decimal CancelItem(decimal total, List<ItemsForSale> itemsForSale);
    }
}
