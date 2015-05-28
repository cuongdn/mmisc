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
            SetNullDatabaseInitializer<SchoolContext>();
        }
    }
}
