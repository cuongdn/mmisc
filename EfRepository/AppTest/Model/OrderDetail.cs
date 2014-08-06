using System;
using Core;

namespace AppTest
{
	public partial class OrderDetail : Entity
	{
		public OrderDetail()
		{
		}
		public int OrderID { get; set; } //int
		public int ProductID { get; set; } //int
		public int Quantity { get; set; } //int
		public decimal UnitCost { get; set; } //money
		public virtual Order Order { get; set; }
	}
}
