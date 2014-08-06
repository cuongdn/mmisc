using System;
using Core;

namespace AppTest
{
	public partial class ShoppingCart : Entity
	{
		public ShoppingCart()
		{
		}
		public int RecordID { get; set; } //int
		public string CartID { get; set; } //nvarchar(50)
		public int Quantity { get; set; } //int
		public int ProductID { get; set; } //int
		public DateTime DateCreated { get; set; } //datetime
		public virtual Product Product { get; set; }
	}
}
