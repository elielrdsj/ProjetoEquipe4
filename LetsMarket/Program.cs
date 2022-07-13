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

            var menuItem = new MenuItem("Menu Principal");
            var products = CreateMainMenu.Create(Product, "Produtos");
            var employees = CreateMainMenu.Create(Employee, "Funcionários");
            var clients = CreateMainMenu.Create(Client, "Clientes");

            var sales = new MenuItem("Vendas");
            sales.Add(new MenuItem("Efetuar Venda", Sales.MakeSale));

            menuItem.Add(products);
            menuItem.Add(employees);
            menuItem.Add(clients);
            menuItem.Add(sales);
            menuItem.Add(new MenuItem("Sair", () => Environment.Exit(0)));

            Menu menu = new Menu();
            menu.Item = menuItem;
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