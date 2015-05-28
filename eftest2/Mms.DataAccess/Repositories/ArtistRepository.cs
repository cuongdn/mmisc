using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.Repositories;
using Mms.DataAccess.Entities;

namespace Mms.DataAccess.Repositories
{
    public class ArtistRepository : Repository<Artist>
    {
        public ArtistRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        public IList<Artist> GetAll()
        {
            return Queryable().ToList();
        }
    }
}
