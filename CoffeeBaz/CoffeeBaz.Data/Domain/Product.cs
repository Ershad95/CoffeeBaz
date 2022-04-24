using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Data.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool Vip { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public int CatergoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
