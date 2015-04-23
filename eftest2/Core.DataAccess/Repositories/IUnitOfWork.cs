using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.DataAccess.Entities;

namespace Core.DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; }
        IRepository<T> Repository<T>() where T : EntityBase;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}