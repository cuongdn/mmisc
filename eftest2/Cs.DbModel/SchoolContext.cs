using Core.DataAccess.Context;
using Core.DataAccess.Repositories;

namespace Cs.DbModel
{
    public class SchoolContext : DataContext
    {
        public SchoolContext()
            : base("name=ConnectionString")
        {
        }

        static SchoolContext()
        {
            System.Data.Entity.Database.SetInitializer<SchoolContext>(null);
        }
    }
}
