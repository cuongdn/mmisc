using DataAccess.Model;
using RepositoryPattern.Infrastructure;
using RepositoryPattern.Service;

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