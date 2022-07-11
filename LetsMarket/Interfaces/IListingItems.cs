using BetterConsoleTables;
using LetsMarket.Logic;

namespace LetsMarket.Interfaces
{
    public interface IListingItems
    {
        void ListItems(List<ItemsForSale> itemsForSale, Table report);
    }
}
