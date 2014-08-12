using DataAccess.Model;
using Repository.Pattern.Repositories;
using Repository.Pattern.Service;

namespace Service
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IRepositoryAsync<Product> repository)
            : base(repository)
        {
        }
    }
}