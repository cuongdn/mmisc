using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Mms.DataAccess.Entities
{
    public class OrderDetail : Entity<int>
    {
        public int OrderId { get; set; } // OrderId
        public int AlbumId { get; set; } // AlbumId
        public int Quantity { get; set; } // Quantity
        public decimal UnitPrice { get; set; } // UnitPrice
        
        public virtual Album Album { get; set; } // FK_InvoiceLine_Album
        public virtual Order Order { get; set; } // FK__InvoiceLi__Invoi__2F10007B
    }
}
