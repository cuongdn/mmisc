using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;
using Cs.DbModel.Dto;
using Cs.DbModel.Entities;

namespace Cs.DbModel.Repositories
{
    public class CourseRepository : Repository<Course>
    {
        public CourseRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Course GetById(int id)
        {
            return DbSet
                .Where(x => x.Id == id)
                .Include("Department").SingleOrDefault();
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            return await DbSet.OrderBy(x => x.Title)
                .Include("Department")
                .Select(x => new CourseDto
                {
                    Id = x.Id,
                    Credits = x.Credits,
                    Title = x.Title,
                    DepartmentName = x.Department.Name
                })
                .ToListAsync();
        }

        public IList<Course> GetAll()
        {
            return DbSet.OrderBy(x => x.Title).ToList();
        }
    }
}
