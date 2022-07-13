using LetsMarket.Enums;
using Sharprompt;

namespace LetsMarket.Logic
{

    public class MenuItem
    {
        public MenuType Type { get; }
        private static MenuItem _root;
        private MenuItem parent = null;
        public string title { get; set; }
        public List<MenuItem> items { get; set; }
        public  Action action;
                
        public MenuItem(string title)
        {
            this.title = title;
            items = new List<MenuItem>();
            if (_root == null) _root = this;
            Type = MenuType.Submenu;
        }

        public MenuItem(string title, Action action) : this(title)
        {
            this.action = action;
            Type = MenuType.Command;
        }

        public void Add(MenuItem menuItem)
        {
            menuItem.parent = this;
            items.Add(menuItem);
        }
        public override string ToString()
        {
            return title;
        }
    }
}
