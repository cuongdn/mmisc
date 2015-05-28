using Core.DataAccess.Repositories;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Repositories
{
    public class CourseRepository : Repository<Course>
    {
        public CourseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
