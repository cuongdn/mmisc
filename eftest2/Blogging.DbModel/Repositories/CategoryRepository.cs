using System.Collections.Generic;
using System.Linq;
using Blogging.DbModel.Dto;
using Blogging.DbModel.Entities;
using Core.DataAccess.Repositories;

namespace Blogging.DbModel.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IList<Category> GetAll()
        {
            return DbSet.OrderByDescending(x => x.Id)
                        .ToList();
        }

        public IList<CategoryDto> GetCategories()
        {
            return DbSet.OrderByDescending(x => x.Id)
                        .Select(x => new CategoryDto()
                        {
                            Id = x.Id,
                            CategoryName = x.CategoryName,
                        })
                        .ToList();
        }
    }
}
