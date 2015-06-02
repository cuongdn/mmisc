using System;
using System.Threading;
using System.Threading.Tasks;
using Core.DataAccess.Context;

namespace Core.DataAccess.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IDataContext DataContext { get; }
        T Repository<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}