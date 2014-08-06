using System;
using System.Collections.Generic;
using Core;

namespace AppTest
{
	public partial class Order : Entity
	{
		public Order()
		{
			this.OrderDetails = new List<OrderDetail>();
		}
		public int OrderID { get; set; } //int
		public int CustomerID { get; set; } //int
		public DateTime OrderDate { get; set; } //datetime
		public DateTime ShipDate { get; set; } //datetime
		public virtual Customer Customer { get; set; }
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
