using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Interfaces
{
    public interface IEntity
    {
        void Create();
        void List();
        void Update();
        void Delete();
    }
}
