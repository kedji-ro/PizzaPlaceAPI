using Microsoft.EntityFrameworkCore;
using PizzaPlaceAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlaceAPI.DataAccess
{
    public class PizzaPlaceDb : DbContext
    {
        public PizzaPlaceDb(DbContextOptions<PizzaPlaceDb> options)
        : base(options) { }

        public DbSet<Pizzas> Pizzas => Set<Pizzas>();
        public DbSet<PizzaTypes> PizzaTypes => Set<PizzaTypes>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Size> Sizes => Set<Size>();

        public DbSet<Orders> Orders => Set<Orders>();
        public DbSet<OrderDetails> OrderDetails => Set<OrderDetails>();
    }
}
