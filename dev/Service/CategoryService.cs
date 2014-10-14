using DataAccess.Model;
using RepositoryPattern.Ef;
using RepositoryPattern.Infrastructure;

namespace Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IRepositoryAsync<Category> repository)
            : base(repository)
        {
        }
    }
}