using CoffeeBaz.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public Task<bool> Delete(Category entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Category entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Category entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
