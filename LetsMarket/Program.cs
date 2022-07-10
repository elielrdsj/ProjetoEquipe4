using LetsMarket.Logic;
using LetsMarket.Db;
using LetsMarket.View;
using Sharprompt;

namespace LetsMarket
{
    public class Program
    {     
        public static void Main()
        {
            ConfiguraPrompt();
            Console.Title = "Let's Store";

            Login.VerifyLogin();

            var menu = new MenuItem("Menu Principal");

            var products = new MenuItem("Produtos");
            products.Add(new MenuItem("Cadastrar Produtos", Product.RegisterProduct));
            products.Add(new MenuItem("Listar Produtos", Product.ListProducts));
            products.Add(new MenuItem("Editar Produtos", Product.EditProduct));
            products.Add(new MenuItem("Remover Produtos", Product.RemoveProduct));

            var employees = new MenuItem("Funcionários");
            employees.Add(new MenuItem("Cadastrar Funcionários", Employee.RegisterEmployee));
            employees.Add(new MenuItem("Listar Funcionários", Employee.ListEmployees));
            employees.Add(new MenuItem("Editar Funcionários", Employee.EditEmployee));
            employees.Add(new MenuItem("Remover Funcionários", Employee.RemoveEmployee));

            var clients = new MenuItem("Clientes");
            clients.Add(new MenuItem("Cadastrar Clientes", Client.RegisterClient));
            clients.Add(new MenuItem("Listar Clientes", Client.ListClients));
            clients.Add(new MenuItem("Editar Clientes", Client.EditClient));
            clients.Add(new MenuItem("Remover Clientes", Client.RemoveClient));

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