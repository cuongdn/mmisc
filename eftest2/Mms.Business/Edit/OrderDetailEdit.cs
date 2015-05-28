using System;
using Core.Business.Common;
using Core.Business.Utils;
using Mms.DataAccess.Entities;

namespace Mms.Business.Edit
{
    public class OrderDetailEdit : ModelEditBase
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
        
        public static OrderDetailEdit New()
        {
            return ModelHelper.NewModelObject<OrderDetailEdit>();
        }
        
        public static OrderDetailEdit Get(int id)
        {
            return ObjectUtil.GetEdit<OrderDetailEdit, OrderDetail>(id);
        }
        
        public override bool Upsert(bool forceUpdate = false)
        {
            return ObjectUtil.Upsert<OrderDetailEdit, OrderDetail>(this, forceUpdate);
        }
        
        public override bool Delete()
        {
            return ObjectUtil.Delete<OrderDetailEdit, OrderDetail>(this);
        }
    }
}
