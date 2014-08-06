using System;
using System.Collections.Generic;
using Core;

namespace AppTest
{
	public partial class Category : Entity
	{
		public Category()
		{
			this.Products = new List<Product>();
		}
		public int CategoryID { get; set; } //int
		public string CategoryName { get; set; } //nvarchar(50)
		public virtual ICollection<Product> Products { get; set; }
	}
}
