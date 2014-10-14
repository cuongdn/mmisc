using DataAccess.Model;
using RepositoryPattern.Ef;
using RepositoryPattern.Infrastructure;

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