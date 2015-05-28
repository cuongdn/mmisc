using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.Repositories;
using Mms.DataAccess.Entities;

namespace Mms.DataAccess.Repositories
{
    public class GenreRepository : Repository<Genre>
    {
        public GenreRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        public IList<Genre> GetAll()
        {
            return Queryable().ToList();
        }
    }
}
