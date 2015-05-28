using System;
using Core.Business.Common;
using Core.Business.Utils;
using Mms.DataAccess.Entities;

namespace Mms.Business.Edit
{
    public class OrderEdit : ModelEditBase
    {
        public override object IdValue
        {
            get { return Id; }
        }
        
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } // OrderDate
        public string Username { get; set; } // Username
        public string FirstName { get; set; } // FirstName
        public string LastName { get; set; } // LastName
        public string Address { get; set; } // Address
        public string City { get; set; } // City
        public string State { get; set; } // State
        public string PostalCode { get; set; } // PostalCode
        public string Country { get; set; } // Country
        public string Phone { get; set; } // Phone
        public string Email { get; set; } // Email
        public decimal Total { get; set; } // Total
        
        public static OrderEdit New()
        {
            return ModelHelper.NewModelObject<OrderEdit>();
        }
        
        public static OrderEdit Get(int id)
        {
            return ObjectUtil.GetEdit<OrderEdit, Order>(id);
        }
        
        public override bool Upsert(bool forceUpdate = false)
        {
            return ObjectUtil.Upsert<OrderEdit, Order>(this, forceUpdate);
        }
        
        public override bool Delete()
        {
            return ObjectUtil.Delete<OrderEdit, Order>(this);
        }
    }
}
