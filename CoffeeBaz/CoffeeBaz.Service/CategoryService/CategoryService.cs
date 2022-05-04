using CoffeeBaz.Data.DataRepository;
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
        private readonly IRepository<Category> _repository;
        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public Task<bool> Delete(Category entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }


        public async Task<Category> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        public async Task<bool> Insert(Category entity, CancellationToken cancellationToken = default)
        {
            return await _repository.Insert(entity, cancellationToken);
        }

        public async Task<bool> Update(Category entity, CancellationToken cancellationToken = default)
        {
            return await _repository.Update(entity, cancellationToken);
        }

        public async Task<IList<Category>> GetAllEntites()
        {
            return _repository.Entity.ToList();
        }
        


    }
}
