using BetterConsoleTables;
using LetsMarket.Db;
using LetsMarket.Enums;
using LetsMarket.Interfaces;
using LetsMarket.View;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket.Logic
{
    public class Client : StandardMessages, IEntity
    {
        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = "O Documento é Obrigatório")]
        [MinLength(11)]
        [MaxLength(11)]
        public string Document { get; set; }


        [Display(Name = "Categoria")]
        public ClientCategory? Category { get; set; }

        public void Create()
        {
            var client = Prompt.Bind<Client>();

            if (!ShowMessageAndConfirmCreate())
                return;

            Database.Clients.Add(client);
            Database.Save(DatabaseOption.Clients);
        }
        public void List()
        {
            ListingMessage();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Database.Clients);
            Console.WriteLine(table.ToString());
        }

        public override string ToString()
        {
            return $"{Name} - {Document}";
        }

        public void Update()
        {
            var client = Prompt.Select("Selecione o Cliente para Editar", Database.Clients, defaultValue: Database.Clients[0]);

            Prompt.Bind(client);

            Database.Save(DatabaseOption.Clients);
        }

        public void Delete()
        {
            if (Database.Clients.Count == 1)
            {
                DeleteErrorMessage();
                return;
            }

            var client = Prompt.Select("Selecione o Cliente para Remover", Database.Clients);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            Database.Clients.Remove(client);
            Database.Save(DatabaseOption.Clients);
        }
    }
}