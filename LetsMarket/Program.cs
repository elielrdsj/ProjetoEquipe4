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

            var products = new MenuItem("Produtos");
            products.Add(new MenuItem("Cadastrar Produtos", Product.Create));
            products.Add(new MenuItem("Listar Produtos", Product.List));
            products.Add(new MenuItem("Editar Produtos", Product.Update));
            products.Add(new MenuItem("Remover Produtos", Product.Delete));

            var employees = new MenuItem("Funcionários");
            employees.Add(new MenuItem("Cadastrar Funcionários", Employee.Create));
            employees.Add(new MenuItem("Listar Funcionários", Employee.List));
            employees.Add(new MenuItem("Editar Funcionários", Employee.Update));
            employees.Add(new MenuItem("Remover Funcionários", Employee.Delete));

            var clients = new MenuItem("Clientes");
            clients.Add(new MenuItem("Cadastrar Clientes", Client.Create));
            clients.Add(new MenuItem("Listar Clientes", Client.List));
            clients.Add(new MenuItem("Editar Clientes", Client.Update));
            clients.Add(new MenuItem("Remover Clientes", Client.Delete));

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