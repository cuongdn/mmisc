using System.Collections.Generic;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Mms.DataAccess.Entities;
using Mms.DataAccess.Repositories;

namespace Mms.Business.Preview
{
    public class OrderDetailPreview : ModelBase
    {
        public override object IdValue
        {
            get { return Id; }
        }
        
        public int Id { get; set; }
        public int OrderId { get; set; } // OrderId
        public int AlbumId { get; set; } // AlbumId
        public int Quantity { get; set; } // Quantity
        public decimal UnitPrice { get; set; } // UnitPrice
        
        public static IList<OrderDetailPreview> GetList()
        {
            var repo = UowFactory.Get().Repository<OrderDetailRepository>();
            return ModelHelper.FetchList<OrderDetailPreview, OrderDetail>(repo.GetAll());
        }
    }
}
