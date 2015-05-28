using Core.DataAccess.Repositories;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
