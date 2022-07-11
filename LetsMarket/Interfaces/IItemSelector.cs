using LetsMarket.Logic;

namespace LetsMarket.Interfaces
{
    public interface IItemSelector
    {
        void SelectItem(List<Product> products, List<ItemsForSale> itemsForSale, decimal total, Product[] exitAndCancelOptions);
    }
}
