using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.Context;
using Core.DataAccess.Repositories;
using Core.DataAccess.Uow;
using Cs.DbModel.Entities;

namespace Cs.DbModel.Repositories
{
    public class EnrollmentRepository : Repository<Enrollment>
    {
        public EnrollmentRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IList<Enrollment> GetByStudentId(int id)
        {
            return DbSet.Include("Course")
                        .Where(x => x.StudentId == id)
                        .ToList();
        }
    }
}
