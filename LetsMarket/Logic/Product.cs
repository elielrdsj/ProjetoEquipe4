using BetterConsoleTables;
using LetsMarket.Db;
using Sharprompt;
using System.ComponentModel.DataAnnotations;
using LetsMarket.Interfaces;
using LetsMarket.Enums;

namespace LetsMarket.Logic
{
    public class Product : IEntity
    {
        IStandardMessages _standardMessage = new StandardMessages();

        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é obrigatório")]
        public string Code { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Description { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O preço é obrigatório")]
        public decimal Price { get; set; }

        public void Create()
        {
            var product = Prompt.Bind<Product>();

            if (!_standardMessage.ShowMessageAndConfirmCreate())
                return;

            Database.Products.Add(product);
            Database.Save(DatabaseOption.Products);
        }

        public void List()
        {
            _standardMessage.ListingMessage();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Database.Products);
            Console.WriteLine(table.ToString());
        }

        public void Update()
        {
            var produto = Prompt.Select("Selecione o Produto para Editar", Database.Products, defaultValue: Database.Products[0]);

            Prompt.Bind(produto);

            Database.Save(DatabaseOption.Products);
        }

        public void Delete()
        {
            var product = Prompt.Select("Selecione o Produto para Remover", Database.Products);

            if (!_standardMessage.ShowMessageAndConfirmDelete())
                return;

            Database.Products.Remove(product);
            Database.Save(DatabaseOption.Products);
        }

        public override string ToString()
        {
            return Description;
        }

    }
}