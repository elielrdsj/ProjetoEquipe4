using LetsMarket.Enums;
using LetsMarket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LetsMarket.Logic
{
    public static class CreateMainMenu
    {
        public static MenuItem Create(IEntity entity, string description)
        {
            var entityMenu = new MenuItem(description);
            entityMenu.Add(new MenuItem(MenuCategory.Cadastrar + " " + description, entity.Create));
            entityMenu.Add(new MenuItem(MenuCategory.Listar + " " + description, entity.List));
            entityMenu.Add(new MenuItem(MenuCategory.Editar + " " + description, entity.Update));
            entityMenu.Add(new MenuItem(MenuCategory.Remover + " " + description, entity.Delete));

            return entityMenu;
        }
    }
}