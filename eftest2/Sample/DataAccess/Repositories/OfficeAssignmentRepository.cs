using Core.DataAccess.Repositories;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Repositories
{
    public class OfficeAssignmentRepository : Repository<OfficeAssignment>
    {
        public OfficeAssignmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
