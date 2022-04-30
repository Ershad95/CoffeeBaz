using CoffeeBaz.Data.DataRepository;
using CoffeeBaz.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Product entity, CancellationToken cancellationToken = default)
        {
            return await _repository.Delete(entity, cancellationToken);
        }


        public async Task<Product> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        public async Task<bool> Insert(Product entity, CancellationToken cancellationToken = default)
        {
            return await _repository.Insert(entity, cancellationToken);
        }

        public async Task<bool> Update(Product entity, CancellationToken cancellationToken = default)
        {
            return await _repository.Update(entity, cancellationToken);
        }

        public async Task<IList<Product>> GetAllEntites()
        {
            return _repository.Entity.ToList();
        }
    }
}
