using System;
using System.Collections.Generic;
using Repository.Pattern.Ef6;

namespace DataAccess.Model
{
    public class Order : Entity
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public int OrderId { get; set; } //int
        public int CustomerId { get; set; } //int
        public DateTime OrderDate { get; set; } //datetime
        public DateTime ShipDate { get; set; } //datetime
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}