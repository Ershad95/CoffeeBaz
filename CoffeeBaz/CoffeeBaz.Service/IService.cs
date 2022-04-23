using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Service
{
    public interface IService<Entiry>
    {
        bool Insert(Entiry entity);
        bool Update(Entiry entity);
        bool Delete(Entiry entity);
        Entiry GetById(int id);
    }
}
