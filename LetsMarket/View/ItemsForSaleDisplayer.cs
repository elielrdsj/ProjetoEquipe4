using BetterConsoleTables;
using LetsMarket.Db;
using LetsMarket.Interfaces;

namespace LetsMarket.Logic
{
    public class ItemsForSaleDisplayer : IItemsForSaleDisplayer
    {
        private readonly IListingItems _listItems;
        public ItemsForSaleDisplayer(IListingItems listItems)
        {
            this._listItems = listItems;
        }
        public void DisplayItemsForSale(List<ItemsForSale> itemsForSale)
        {
            Console.Clear();
            Console.WriteLine("EFETUANDO UMA VENDA");
            var report = new Table(TableConfiguration.UnicodeAlt());
            var largestColumn = Database.Products.Max(x => x.Description);

            if (itemsForSale.Count > 0)
            {
                _listItems.ListItems(itemsForSale, report);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
