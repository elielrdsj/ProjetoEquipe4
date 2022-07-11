using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Logic
{
    public class ItemsForSale
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get => Quantity * UnitPrice; }

        public override string ToString()
        {
            return Description;
        }

        public ItemsForSale(Product product, int quantity)
        {
            Code = product.Code;
            Description = product.Description;
            UnitPrice = product.Price;
            Quantity = quantity;
        }
    }
}
