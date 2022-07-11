using LetsMarket.Logic;

namespace LetsMarket.Interfaces
{
    public interface IExitAndCancelOptionsCreator
    {
        Product[] CreateExitAndCancelOptions(List<Product> products);
    }
}
