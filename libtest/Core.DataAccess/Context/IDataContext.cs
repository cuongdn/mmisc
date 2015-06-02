using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.DataAccess.Context
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
