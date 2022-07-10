using LetsMarket.Interfaces;
using Sharprompt;

namespace LetsMarket.Logic
{
    public class ItemCanceller : IItemCanceller
    {
        public decimal CancelItem(decimal total, List<ItemsForSale> itemsForSale)
        {
            Console.Clear();
            Console.WriteLine("Selecione o item a ser cancelado");
            var itemToCancel = Prompt.Select("Selecione o item a ser cancelado", itemsForSale);
            itemsForSale.Remove(itemToCancel);

            total -= itemToCancel.UnitPrice;
            return total;
        }
    }
}
