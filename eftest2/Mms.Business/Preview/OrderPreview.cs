using System;
using System.Collections.Generic;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Mms.DataAccess.Entities;
using Mms.DataAccess.Repositories;

namespace Mms.Business.Preview
{
    public class OrderPreview : ModelBase
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
        
        public static IList<OrderPreview> GetList()
        {
            var repo = UowFactory.Get().Repository<OrderRepository>();
            return ModelHelper.FetchList<OrderPreview, Order>(repo.GetAll());
        }
    }
}
