using BetterConsoleTables;
using LetsMarket.Db;
using LetsMarket.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Sharprompt;

namespace LetsMarket.Logic
{
    public class SalesProcessor : ISalesProcesor
    {
        private readonly IExitAndCancelOptionsCreator _exitAndCancelOptionsCreator;
        private readonly IItemSelector _itemSelector;
        private readonly IItemsForSaleDisplayer _itemsForSaleDisplayer;
        private readonly ITotalPurchase _totalPurchase;
        private readonly IExitAndCancelOptionsRemover _exitAndCancelOptionsRemover;
        //public void ProcessSales()
        //{
        //    var serviceCollection = new ServiceCollection()
        //        .AddScoped<IListingItems, ListingItems>()
        //        .AddScoped<IItemsForSaleDisplayer, ItemsForSaleDisplayer>()
        //        .AddScoped<ITotalPurchase, TotalPurchase>()
        //        .AddScoped<IExitAndCancelOptionsCreator, ExitAndCancelOptionsCreator>()
        //        .AddScoped<IExitAndCancelOptionsRemover, ExitAndCancelOptionsRemover>()
        //        .AddScoped<IItemCanceller, ItemCanceller>()
        //        .AddScoped<IItemSelector, ItemSelector>();

        //    var serviceProvider = serviceCollection.BuildServiceProvider();
        //    using (var stream = File.OpenRead("sales.txt"))
        //    {
        //        var salesProcessor = serviceProvider.Ge
        //    }

            
        //}

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