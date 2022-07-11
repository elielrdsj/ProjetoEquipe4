using LetsMarket.Interfaces;

namespace LetsMarket.Logic
{
    public class TotalPurchase : ITotalPurchase
    {
        public void TotalOfPurchase(decimal total, Product closeSale, Product product)
        {
            if (product != closeSale)
                return;

            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"TOTAL DA COMPRA: {total}");
            Console.ForegroundColor = color;
            Console.ReadKey();
        }
    }
}