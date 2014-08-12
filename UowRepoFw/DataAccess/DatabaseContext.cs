using DataAccess.Model;
using DataAccess.Model.Mapping;
using RepositoryPattern.Ef;
using System;
using System.Data.Entity;

namespace DataAccess
{
    public class DatabaseContext : DataContext
    {
        static DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>(null);
        }

        public DatabaseContext()
            : base("Name=DataContext")
        {
            Database.Log = Console.Write;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.Configurations.Add(new CategoryMap());
            mb.Configurations.Add(new CustomerMap());
            mb.Configurations.Add(new OrderMap());
            mb.Configurations.Add(new OrderDetailMap());
            mb.Configurations.Add(new ProductMap());
            mb.Configurations.Add(new ReviewMap());
            mb.Configurations.Add(new ShoppingCartMap());
        }
    }
}