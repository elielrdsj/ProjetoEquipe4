using LetsMarket.Enums;
using LetsMarket.Interfaces;
using Sharprompt;

namespace LetsMarket.Logic
{

    public class Menu : IMenu
    {
        public MenuItem Item { get; set; }
        public  MenuItem SubItem { get; set; }


        public void Execute()
        {
            SubItem = Item;
            
                Console.Clear();
                SubItem = Prompt.Select(SubItem.title, SubItem.items);
                SubItem = Prompt.Select(SubItem.title, SubItem.items);
                SubItem.action();
                Console.ReadKey();
                Execute();
        }
    }
}