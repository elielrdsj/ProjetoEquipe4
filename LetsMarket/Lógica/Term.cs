using BetterConsoleTables;
using Sharprompt;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LetsSpeak
{
    public class Term
    {
        [Display(Name = "Expressão")]
        [Required]
        public string expression { get; set; }

        [Display(Name = "Significado")]
        [Required]
        public string meaning { get; set; }

        public static void RecordExpressions()
        {
            var term = Prompt.Bind<Term>();
            foreach (char c in term.expression)
            {
                if (!Char.IsLetter(c))
                {
                    return;
                }
            }
            if (Database.terms.ContainsKey(term.expression))
            {
                Console.WriteLine("O termo já existe");
                return;
            }else
            Database.Add(term.expression, term.meaning);
            

            if (!Prompt.Confirm("Deseja Salvar?"))
                return;

            Database.Save();

        }

        public static void ListExpressions()
        {
            Console.WriteLine("Listando Expressões");
            Console.WriteLine();

            foreach (KeyValuePair<string, string> entry in Database.terms)
            {
                Console.WriteLine(entry.Key + " " + entry.Value);
            }
        }

        public static void SearchExpressions()
        {
            Console.WriteLine("Insira a expressão ou parte da expressão que quer registrar:");
            var reference = Console.ReadLine();

                foreach (var key in Database.terms.Keys)
            {
                if (key.Contains(reference, StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine(key + Database.terms[key]);
                }
            }
        }
    }
}