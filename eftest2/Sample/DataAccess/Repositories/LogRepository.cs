using Core.DataAccess.Repositories;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Repositories
{
    public class LogRepository : Repository<Log>
    {
        public LogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
