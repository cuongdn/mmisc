using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.Repositories;
using Mms.DataAccess.Entities;

namespace Mms.DataAccess.Repositories
{
    public class CartRepository : Repository<Cart>
    {
        public CartRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        public IList<Cart> GetAll()
        {
            return Queryable().ToList();
        }
    }
}
