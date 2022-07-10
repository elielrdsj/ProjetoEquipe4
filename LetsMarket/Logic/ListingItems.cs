using BetterConsoleTables;
using LetsMarket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Logic
{
    public class ListingItems : IListingItems
    {
        public void ListItems(List<ItemsForSale> itemsForSale, Table report)
        {
            report.From<ItemsForSale>(itemsForSale);
            Console.WriteLine(report.ToString());
        }
    }
}
