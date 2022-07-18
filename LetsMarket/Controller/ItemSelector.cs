using LetsMarket.Interfaces;
using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Logic
{
    public class ItemSelector : IItemSelector
    {
        private readonly IItemCanceller _itemCanceller;
        public ItemSelector(IItemCanceller itemCanceller)
        {
            this._itemCanceller = itemCanceller;
        }
        public void SelectItem(List<Product> products, List<ItemsForSale> itemsForSale, decimal total, Product[] exitAndCancelOptions)
        {
            Product product = Prompt.Select("Selecione o produto", products);
            if (product == exitAndCancelOptions[0] || product == exitAndCancelOptions[1] || product == exitAndCancelOptions[2])
                return;
            var quantity = Prompt.Input<int>("Informe a quantidade", defaultValue: 1);
            var item = new ItemsForSale(product, quantity);
            itemsForSale.Add(item);
            total += item.Subtotal;

            if (product != exitAndCancelOptions[2])
                return;
            total = _itemCanceller.CancelItem(total, itemsForSale);
        }
    }
}
