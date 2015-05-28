using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.Context;
using Core.DataAccess.Repositories;
using Cs.DbModel.Entities;

namespace Cs.DbModel.Repositories
{
    public class InstructorRepository : Repository<Instructor>
    {
        public InstructorRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Instructor GetById(int id)
        {
            return DbSet.Include("OfficeAssignment")
                        .SingleOrDefault(x => x.Id == id);
        }

        public async Task<IList<Instructor>> GetAllAsync()
        {
            return await DbSet.OrderBy(x => x.FirstMidName)
                .ThenBy(x => x.LastName)
                .Include("OfficeAssignment")
                .ToListAsync();
        }
    }
}
