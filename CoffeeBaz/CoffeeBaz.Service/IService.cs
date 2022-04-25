using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Service
{
    public interface IService<Entiry>
    {
         Task<bool> Insert(Entiry entity, CancellationToken cancellationToken=default);
         Task<bool> Update(Entiry entity, CancellationToken cancellationToken = default);
         Task<bool> Delete(Entiry entity, CancellationToken cancellationToken = default);
         Task<Entiry> GetById(int id, CancellationToken cancellationToken=default);
    }
}
