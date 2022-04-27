using CoffeeBaz.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Service.OrderService
{
    public class OrderService : IOrderService
    {
        public Task<bool> Delete(Order entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllEntites()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetById(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Order entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Order entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        Task<IList<Order>> IService<Order>.GetAllEntites()
        {
            throw new NotImplementedException();
        }
    }
}
