using System.Data.Entity;
using Blogging.DbModel;
using Core.DataAccess.Repositories;
using StructureMap.Configuration.DSL;

namespace Blogging.Web.Dependency
{
    public class ScanningRegistry : Registry
    {
        public ScanningRegistry()
        {
            For<IUnitOfWork>().Use<UnitOfWork>();
            For<DbContext>().Use<BlogContext>();
            For(typeof(IRepository<>)).Use(typeof(Repository<>));
        }
    }
}