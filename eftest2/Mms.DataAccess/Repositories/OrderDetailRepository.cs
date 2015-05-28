using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.Repositories;
using Mms.DataAccess.Entities;

namespace Mms.DataAccess.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>
    {
        public OrderDetailRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        public IList<OrderDetail> GetAll()
        {
            return Queryable().ToList();
        }
    }
}
