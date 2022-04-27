using CoffeeBaz.Data.DataRepository;
using CoffeeBaz.Data.Domain;
using CoffeeBaz.Shared.DTO;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Service.TableService
{
    public class TableService : ITableService
    {
        private readonly IRepository<Table> _repository;
        private readonly IConfiguration _config;
        public TableService(IRepository<Table> repository,IConfiguration configuration)
        {
            _config = configuration;
            _repository = repository;
        }
        public async Task<bool> Delete(Table entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async  Task<IList<Table>> GetAllEntites()
        {
            return _repository.Entity.ToList();
        }
        

        public async Task<Table> GetById(int id,CancellationToken cancellationToken)
        {
            return await _repository.GetById(id,cancellationToken);
        }

        public async Task<bool> Insert(Table entity,CancellationToken cancellationToken)
        {
            return await _repository.Insert(entity,cancellationToken);
        }

        public async Task<bool> Update(Table entity, CancellationToken cancellationToken)
        {
            return  await _repository.Update(entity);
        }
    }
}
