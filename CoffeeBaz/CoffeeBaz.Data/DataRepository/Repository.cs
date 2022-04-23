using CoffeeBaz.Data.Context;
using CoffeeBaz.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool Delete(T entity)
        {
            try
            {
                _coffeBazContext.Remove(entity);
                _coffeBazContext.SaveChangesAsync();
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

        public T GetById(int id)
        {
            return Entity.FirstOrDefault(x => x.Id == id);
        }

        public bool Insert(T entity)
        {
            try
            {
                _coffeBazContext.Add(entity);
                _coffeBazContext.SaveChangesAsync();
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

        public bool Update(T entity)
        {
            try
            {
                _coffeBazContext.Update(entity);
                _coffeBazContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
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
