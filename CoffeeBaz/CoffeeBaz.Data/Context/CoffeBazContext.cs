using CoffeeBaz.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Data.Context
{
    public class CoffeBazContext:DbContext
    {
        
      
        public CoffeBazContext(DbContextOptions<CoffeBazContext> options): base(options){}

        public DbSet<Table> Tables { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
