using System;
using System.Collections.Generic;
using Core;

namespace AppTest
{
	public partial class Customer : Entity
	{
		public Customer()
		{
			this.Orders = new List<Order>();
		}
		public int CustomerID { get; set; } //int
		public string FullName { get; set; } //nvarchar(50)
		public string EmailAddress { get; set; } //nvarchar(50)
		public string Password { get; set; } //nvarchar(50)
		public virtual ICollection<Order> Orders { get; set; }
	}
}
