using System.Data.Entity;
using Core.DataAccess.Context;
using Core.DataAccess.Repositories;

namespace Sample.DataAccess.Context
{
    public class MyDbContext : DataContext
    {
        static MyDbContext()
        {
            Database.SetInitializer<MyDbContext>(null);
        }

        public MyDbContext()
            : base("Name=MyDbContext")
        {
        }
    }
}
