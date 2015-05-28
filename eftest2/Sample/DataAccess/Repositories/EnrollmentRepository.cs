using Core.DataAccess.Repositories;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Repositories
{
    public class EnrollmentRepository : Repository<Enrollment>
    {
        public EnrollmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
