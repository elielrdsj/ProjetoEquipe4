using LetsMarket.Logic;

namespace LetsMarket.Interfaces
{
    public interface IExitAndCancelOptionsCreation
    {
        Product[] CreateExitAndCancelOptions(List<Product> products);
    }
}
