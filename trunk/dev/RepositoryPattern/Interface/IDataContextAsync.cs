using System.Threading;
using System.Threading.Tasks;
using RepositoryPattern.Interface;

namespace RepositoryPattern.DataContext
{
    public interface IDataContextAsync : IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
    }
}