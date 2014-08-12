using DataAccess.Model;
using RepositoryPattern.Infrastructure;
using RepositoryPattern.Service;

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