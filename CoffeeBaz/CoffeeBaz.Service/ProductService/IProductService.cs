using CoffeeBaz.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Service.ProductService
{
    public interface IProductService:IService<Product>
    {
       Task<IList<Product>> GetAllProductByCategory(int categoryId);
    }
}
