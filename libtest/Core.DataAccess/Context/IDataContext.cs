using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Core.DataAccess.Context
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
