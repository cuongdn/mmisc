using DataAccess.Model;
using Repository.Pattern.Repositories;
using Service.Pattern;

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