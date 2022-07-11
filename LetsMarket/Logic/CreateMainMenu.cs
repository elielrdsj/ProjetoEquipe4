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
            entityMenu.Add(new MenuItem("Cadastrar " + description, entity.Create));
            entityMenu.Add(new MenuItem("Listar " + description, entity.List));
            entityMenu.Add(new MenuItem("Editar " + description, entity.Update));
            entityMenu.Add(new MenuItem("Remover " + description, entity.Delete));

            return entityMenu;
        }
    }
}
