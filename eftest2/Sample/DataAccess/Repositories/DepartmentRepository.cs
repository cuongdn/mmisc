using Core.DataAccess.Repositories;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Repositories
{
    public class DepartmentRepository : Repository<Department>
    {
        public DepartmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
