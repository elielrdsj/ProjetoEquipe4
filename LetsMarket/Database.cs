using Bogus;
using CsvHelper;
using System.Globalization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Data;

namespace LetsSpeak
{
    public enum DatabaseOption { Terms }

    public class Database
    {
        private static readonly string _rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string _termsDb = Path.Combine(_rootDirectory, "terms.json");

        public static Dictionary<string, string> terms = new Dictionary<string, string>();

        static Database()
        {
            InitializeDatabase();
        }

        public static void InitializeDatabase()
        {
            if (!File.Exists(_termsDb))
            {
                terms.Add("Expressões", "Significados");
                
                Save();
            }
            Load();
        }

        private static void Load()
        {
            JsonSerializer termDeserializer = new JsonSerializer();
            using (StreamReader reader = new(_termsDb))
            using (JsonTextReader tReader = new JsonTextReader(reader))
            {
                var termos = termDeserializer.Deserialize(tReader) as Dictionary<string, string>;
                terms = termos ?? new Dictionary<string, string>();
            }
        }

        public static void Save()
        {
            Console.WriteLine("Salvando...");

            JsonSerializer termSerializer = new JsonSerializer();
            using (StreamWriter writer = new StreamWriter(_termsDb))
                using (JsonTextWriter tWriter = new JsonTextWriter(writer))
            {
                termSerializer.Serialize(tWriter, terms);
            }            
            Console.WriteLine("Salvo.");
        }
        public static void Add(string s1, string s2)
        {
            terms.Add(s1, s2);
        }
    }
}
