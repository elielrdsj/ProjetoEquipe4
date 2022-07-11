using LetsMarket.Interfaces;
using LetsMarket.View;
using Sharprompt;

namespace LetsMarket
{
    public class StandardMessages : IStandardMessages
    {
        public bool ShowMessageAndConfirmCreate()
        {
            return Prompt.Confirm("Deseja Salvar?");
        }
        public bool ShowMessageAndConfirmDelete()
        {
            return Prompt.Confirm("Tem Certeza?", false);
        }
        public void ListingMessage()
        {
            Console.WriteLine("Listando...");
            Console.WriteLine();
        }
        public void DeleteErrorMessage()
        {
            ConsoleInput.WriteError("Não é possível remover todos os usuários.");
            Console.ReadKey();
        }
    }
}
