using System.Collections.Generic;
using System.Linq;
using Blogging.DbModel.Dto;
using Blogging.DbModel.Entities;
using Core.DataAccess.Repositories;

namespace Blogging.DbModel.Repositories
{
    public class BlogRepository : Repository<Blog>
    {
        public BlogRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IList<BlogDto> GetAll()
        {
            return DbSet.Include("Question")
                    .OrderByDescending(x => x.Id)
                    .Select(x => new BlogDto
                    {
                        Id = x.Id,
                        Title = x.Title,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate,
                        CategoryName = x.Category.CategoryName
                    }).ToList();
        }
    }
}
