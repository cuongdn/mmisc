using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.Repositories;
using Mms.DataAccess.Entities;

namespace Mms.DataAccess.Repositories
{
    public class AlbumRepository : Repository<Album>
    {
        public AlbumRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        public IList<Album> GetAll()
        {
            return Queryable().ToList();
        }
    }
}
