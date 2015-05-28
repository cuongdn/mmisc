using Core.DataAccess.Repositories;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
