using LetsMarket.Logic;
using LetsMarket.Db;
using LetsMarket.View;
using Sharprompt;
using LetsMarket.Interfaces;

namespace LetsMarket
{
    public class Program
    {
        public static void Main()
        {
            IEntity Product = new Product();
            IEntity Employee = new Employee();
            IEntity Client = new Client();

            ConfiguraPrompt();
            Console.Title = "Let's Store";

            Login.VerifyLogin();

            var menu = new MenuItem("Menu Principal");
            var products = CreateMainMenu.Create(Product, "Produtos");
            var employees = CreateMainMenu.Create(Employee, "Funcionários");
            var clients = CreateMainMenu.Create(Client, "Clientes");

            var sales = new MenuItem("Vendas");
            sales.Add(new MenuItem("Efetuar Venda", Sales.MakeSale));

            menu.Add(products);
            menu.Add(employees);
            menu.Add(clients);
            menu.Add(sales);
            menu.Add(new MenuItem("Sair", () => Environment.Exit(0)));

            menu.Execute();
        }


        private static void ConfiguraPrompt()
        {
            Prompt.ColorSchema.Answer = ConsoleColor.White;
            Prompt.ColorSchema.Select = ConsoleColor.White;

            Prompt.Symbols.Prompt = new Symbol("", "");
            Prompt.Symbols.Done = new Symbol("", "");
            Prompt.Symbols.Error = new Symbol("", "");
        }
    }
}