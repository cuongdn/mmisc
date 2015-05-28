using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Mms.DataAccess.Entities
{
    public class Order : Entity<int>
    {
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
        
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } // OrderDetail.FK__InvoiceLi__Invoi__2F10007B
        
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
