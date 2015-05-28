using System;
using System.Threading;
using System.Threading.Tasks;
using Core.DataAccess.Entities;
using Core.DataAccess.Repositories;

namespace Core.DataAccess.Context
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : EntityBase;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}