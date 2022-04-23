using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Data.Domain
{
    public class Order : BaseEntity
    {
        public decimal TotalPrice { get; init; }
        public int TableId { get; init; }


        public int OrderItemId { get;init ; }
        public int ProductId { get;init;}
        public bool Recived { get; init; }
        public bool Paid { get; init; }
        public DateTime PaidDateTime { get; init; }
    }
}
