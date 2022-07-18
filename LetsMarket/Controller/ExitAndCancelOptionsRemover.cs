using LetsMarket.Interfaces;

namespace LetsMarket.Logic
{
    public class ExitAndCancelOptionsRemover : IExitAndCancelOptionsRemover
    {
        public void RemoveExitAndCancelOptions(List<Product> products, Product[] exitAndCancelOptions)
        {
            products.Remove(exitAndCancelOptions[0]);
            products.Remove(exitAndCancelOptions[1]);
            products.Remove(exitAndCancelOptions[2]);
        }
    }
}
