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
        readonly IConfiguration configuration;
        public CoffeBazContext(DbContextOptions<CoffeBazContext> options,IConfiguration configuration): base(options){
        this.configuration = configuration;
        }

        public DbSet<Table> Tables { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
            }
        }
    }
}
