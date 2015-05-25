using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; }
        T Repository<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}