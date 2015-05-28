using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.Repositories;
using Mms.DataAccess.Entities;

namespace Mms.DataAccess.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        public IList<Order> GetAll()
        {
            return Queryable().ToList();
        }
    }
}
