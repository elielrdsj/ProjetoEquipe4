using Sharprompt;

namespace LetsSpeak
{
    public class Program
    {     
        static void Main()
        {
            ConfiguraPrompt();
            Console.Title = "Let's Store";

            var menu = new MenuItem("Menu Principal");

            var produtos = new MenuItem("Iniciar dicionário de termos");
            produtos.Add(new MenuItem("Cadastrar Expressões", Term.RecordExpressions));
            produtos.Add(new MenuItem("Listar Expressões Cadastradas", Term.ListExpressions));
            produtos.Add(new MenuItem("Procurar Expressões", Term.SearchExpressions));

            menu.Add(produtos);
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