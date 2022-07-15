using LetsMarket.Db;
using LetsMarket.Interfaces;

namespace LetsMarket.Logic
{
    public class SalesProcessor : ISalesProcesor
    {
        private readonly IExitAndCancelOptionsCreator _exitAndCancelOptionsCreator;
        private readonly IItemSelector _itemSelector;
        private readonly IItemsForSaleDisplayer _itemsForSaleDisplayer;
        private readonly ITotalPurchase _totalPurchase;
        private readonly IExitAndCancelOptionsRemover _exitAndCancelOptionsRemover;

        public void ProcessSales(Stream stream)
        {
            var total = decimal.Zero;
            var itemsForSale = new List<ItemsForSale>();

            var products = Database.Products.ToList();
            var exitAndCancelOptions = _exitAndCancelOptionsCreator.CreateExitAndCancelOptions(products);

            Product product = null;
            do
            {
                _itemsForSaleDisplayer.DisplayItemsForSale(itemsForSale);

                _itemSelector.SelectItem(products, itemsForSale, total, exitAndCancelOptions);

            } while (product != exitAndCancelOptions[0] && product != exitAndCancelOptions[1]);

            _totalPurchase.TotalOfPurchase(total, exitAndCancelOptions[1], product);

            _exitAndCancelOptionsRemover.RemoveExitAndCancelOptions(products, exitAndCancelOptions);

            return;
        }
    }
}