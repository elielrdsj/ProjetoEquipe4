using BetterConsoleTables;
using LetsMarket.Db;
using LetsMarket.Enums;
using LetsMarket.Interfaces;
using LetsMarket.View;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket.Logic
{
    public class Employee : IEntity
    {
        IStandardMessages _standardMessage = new StandardMessages();

        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Login")]
        [Required]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Categoria")]
        public EmployeeCategory Category { get; set; }

        public void Create()
        {
            var employee = Prompt.Bind<Employee>();

            if (!_standardMessage.ShowMessageAndConfirmCreate())
                return;

            Database.Employees.Add(employee);
            Database.Save(DatabaseOption.Employees);
        }

        //private static string CreateLoginSuggestionBasedOnName(string nome)
        //{
        //    var parts = nome?.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        //    var suggestion = parts?.Length > 0 ? (parts.Length > 1 ? $"{parts[0]}.{parts[parts.Length - 1]}" : $"{parts[0]}") : "";

        //    return suggestion.ToLower();
        //}

        public void List()
        {
            _standardMessage.ListingMessage();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Database.Employees);
            Console.WriteLine(table.ToString());
        }

        public void Update()
        {
            var employee = Prompt.Select("Selecione o Funcionário para Editar", Database.Employees, defaultValue: Database.Employees[0]);

            Prompt.Bind(employee);

            Database.Save(DatabaseOption.Employees);
        }

        public void Delete()
        {
            if (Database.Employees.Count == 1)
            {
                _standardMessage.DeleteErrorMessage();
                return;
            }

            var employee = Prompt.Select("Selecione o Funcionário para Remover", Database.Employees);

            if (!_standardMessage.ShowMessageAndConfirmDelete())
                return;

            Database.Employees.Remove(employee);
            Database.Save(DatabaseOption.Employees);
        }

        public override string ToString()
        {
            return Name;
        }

    }
}