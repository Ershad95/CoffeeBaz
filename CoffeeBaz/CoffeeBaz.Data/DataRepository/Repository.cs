using CoffeeBaz.Data.Context;
using CoffeeBaz.Data.Domain;
using Microsoft.EntityFrameworkCore;
namespace CoffeeBaz.Data.DataRepository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private CoffeBazContext _coffeBazContext { get; set; }
        private DbSet<T> _entities;
        public Repository(CoffeBazContext coffeBazContext)
        {
            _coffeBazContext = coffeBazContext;
            _entities = _coffeBazContext.Set<T>();
        }
        public IQueryable<T> Entity => _entities.AsQueryable();

        public async Task<bool> Delete(T entity,CancellationToken cancellationToken)
        {
            try
            {
                _coffeBazContext.Remove(entity);
                await _coffeBazContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IList<T> templates)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(int tableId = 0, int productId = 0, DateTime? startDate = null, DateTime? endDate = null)
        {
            return Entity.ToList();
        }

        public async Task<T> GetById(int id,CancellationToken cancellationToken)
        {
            return await Entity.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
        }

        public async Task<bool> Insert(T entity,CancellationToken cancellationToken=default)
        {
            try
            {
                _coffeBazContext.Add(entity);
                await _coffeBazContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Insert(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(IList<T> templates)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                _coffeBazContext.Update(entity);
                await _coffeBazContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(IList<T> templates)
        {
            throw new NotImplementedException();
        }

        
    }
}
