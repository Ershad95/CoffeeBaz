using CoffeeBaz.Data.DataRepository;
using CoffeeBaz.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Service.TableService
{
    public class TableService : ITableService
    {
        private readonly IRepository<Table> _repository;
        public TableService(IRepository<Table> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Table entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Table> GetById(int id,CancellationToken cancellationToken)
        {
            return await _repository.GetById(id,cancellationToken);
        }

        public async Task<bool> Insert(Table entity,CancellationToken cancellationToken)
        {
            return await _repository.Insert(entity,cancellationToken);
        }

        public Task<bool> Update(Table entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
