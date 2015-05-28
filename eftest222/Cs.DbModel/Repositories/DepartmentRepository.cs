using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;
using Cs.DbModel.Dto;
using Cs.DbModel.Entities;

namespace Cs.DbModel.Repositories
{
    public class DepartmentRepository : Repository<Department>
    {
        public DepartmentRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<List<DepartmentDto>> GetLookupListAsync()
        {
            return await DbSet.OrderBy(x => x.Name)
                            .Select(x => new DepartmentDto
                            {
                                Id = x.Id,
                                Name = x.Name
                            }).ToListAsync();
        }
    }
}
