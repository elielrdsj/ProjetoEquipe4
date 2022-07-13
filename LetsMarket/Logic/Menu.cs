using LetsMarket.Enums;
using LetsMarket.Interfaces;
using Sharprompt;

namespace LetsMarket.Logic
{

    public class Menu : IMenu
    {
        public MenuItem Item { get; set; }

        public void Execute()
        {
            Console.Clear();
            Item = Prompt.Select(Item.title, Item.items);


            switch (Item.Type)
            {

                case MenuType.Submenu:
                    if (Item.items.Count == 0)
                        Item = Prompt.Select(Item.title, Item.items);
                    break;

                case MenuType.Command:
                    Item.action();
                    Console.ReadKey();
                    break;

                default:
                    break;
            }
            Execute();
        }
    }
}