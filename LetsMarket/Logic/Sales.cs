using BetterConsoleTables;
using LetsMarket.Db;
using LetsMarket.Interfaces;
using Sharprompt;

namespace LetsMarket.Logic
{
    public class Sales
    {
        public static void MakeSale()
        {
            IListingItems _listItems = new ListingItems();
            IItemsForSaleDisplayer _itemsDisplayer = new ItemsForSaleDisplayer(_listItems);
            ITotalPurchase _totalPurchase = new TotalPurchase();
            IExitAndCancelOptionsCreator _exitAndCancelOptionsCreator = new ExitAndCancelOptionsCreator();
            IExitAndCancelOptionsRemover _exitAndCancelOptionsRemover = new ExitAndCancelOptionsRemover();
            IItemCanceller _itemCanceller = new ItemCanceller();
            IItemSelector _itemSelector = new ItemSelector(_itemCanceller);

            var total = decimal.Zero;
            var itemsForSale = new List<ItemsForSale>();

            var products = Database.Products.ToList();
            var exitAndCancelOptions = _exitAndCancelOptionsCreator.CreateExitAndCancelOptions(products);

            Product product = null;
            do
            {
                _itemsDisplayer.DisplayItemsForSale(itemsForSale);

                _itemSelector.SelectItem(products, itemsForSale, total, exitAndCancelOptions);

            } while (product != exitAndCancelOptions[0] && product != exitAndCancelOptions[1]);

            _totalPurchase.TotalOfPurchase(total, exitAndCancelOptions[1], product);

            _exitAndCancelOptionsRemover.RemoveExitAndCancelOptions(products, exitAndCancelOptions);

            return;
        }
    }
}