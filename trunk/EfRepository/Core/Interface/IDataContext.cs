using System;

namespace Core
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
    }
}
