using System.Data.Entity;
using Core.DataAccess.Entities;

namespace Core.DataAccess.Context.Fake
{
    public interface IFakeDbContext : IDataContext
    {
        DbSet<T> Set<T>() where T : class;
        void AddFakeDbSet<TEntity, TFakeDbSet>()
            where TEntity : EntityBase, new()
            where TFakeDbSet : FakeDbSet<TEntity>, IDbSet<TEntity>, new();
    }
}