using System;
using System.Data.Entity;
using Core.DataAccess.Repositories;

namespace Mms.DataAccess.Context
{
    public class EfDbContext : DataContext
    {
        static EfDbContext()
        {
            Database.SetInitializer<EfDbContext>(null);
        }
        
        public EfDbContext() : base("Name=EfDbContext")
        {
        }
    }
}
