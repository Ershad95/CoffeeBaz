using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Core.Utility
{
    public static class FormatPrice
    {
        public static string TomanPrice(this decimal price)
        {
            return price.ToString("n0")+" تومان ";
        }
    }
}
