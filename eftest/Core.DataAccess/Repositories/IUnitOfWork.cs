using System;
using System.Data.Entity;
using Core.DataAccess.Entities;

namespace Core.DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; }
        IRepository<T> Repository<T>() where T : EntityBase;
        void SaveChanges();
    }
}