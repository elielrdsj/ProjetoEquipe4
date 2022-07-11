using LetsMarket.View;
using Sharprompt;

namespace LetsMarket
{
    public class StandardMessages
    {
        public static bool ShowMessageAndConfirmCreate()
        {
            return Prompt.Confirm("Deseja Salvar?");
        }
        public static bool ShowMessageAndConfirmDelete()
        {
            return Prompt.Confirm("Tem Certeza?", false);
        }
        public static void ListingMessage()
        {
            Console.WriteLine("Listando...");
            Console.WriteLine();
        }
        public static void DeleteErrorMessage()
        {
            ConsoleInput.WriteError("Não é possível remover todos os usuários.");
            Console.ReadKey();
        }
    }
}
