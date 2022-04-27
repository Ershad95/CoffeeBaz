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
        public Task<bool> Delete(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllEntites()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        Task<IList<Product>> IService<Product>.GetAllEntites()
        {
            throw new NotImplementedException();
        }
    }
}
