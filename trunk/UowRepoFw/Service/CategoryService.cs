using DataAccess.Model;
using RepositoryPattern.Repositories;
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