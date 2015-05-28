using Core.DataAccess.Repositories;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Repositories
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
