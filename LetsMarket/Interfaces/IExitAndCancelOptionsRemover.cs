using LetsMarket.Logic;

namespace LetsMarket.Interfaces
{
    public interface IExitAndCancelOptionsRemover
    {
        void RemoveExitAndCancelOptions(List<Product> products, Product[] exitAndCancelOptions);
    }
}
