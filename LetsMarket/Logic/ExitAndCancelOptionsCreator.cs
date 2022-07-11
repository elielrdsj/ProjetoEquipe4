using LetsMarket.Interfaces;

namespace LetsMarket.Logic
{
    public class ExitAndCancelOptionsCreator : IExitAndCancelOptionsCreator
    {
        public Product[] CreateExitAndCancelOptions(List<Product> products)
        {
            var exitAndCancelOptions = new Product[]
            {
                new Product
                {
                    Code = "-1",
                    Description = "Sair",
                    Price = 0
                },
                new Product
                {
                    Code = "-1",
                    Description = "Fechar Venda",
                    Price = 0
                },
                new Product
                {
                    Code = "-1",
                    Description = "Cancelar Item",
                    Price = 0
                }
            };
            products.Add(exitAndCancelOptions[0]);
            products.Add(exitAndCancelOptions[1]);
            products.Add(exitAndCancelOptions[2]);
            return exitAndCancelOptions;
        }
    }
}
