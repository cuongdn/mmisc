using Core.DataAccess.Repositories;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Repositories
{
    public class InstructorRepository : Repository<Instructor>
    {
        public InstructorRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
