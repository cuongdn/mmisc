using System;
using System.Collections.Generic;
using Core;

namespace AppTest
{
	public partial class Product : Entity
	{
		public Product()
		{
			this.Reviews = new List<Review>();
			this.ShoppingCarts = new List<ShoppingCart>();
		}
		public int ProductID { get; set; } //int
		public int CategoryID { get; set; } //int
		public string ModelNumber { get; set; } //nvarchar(50)
		public string ModelName { get; set; } //nvarchar(50)
		public string ProductImage { get; set; } //nvarchar(50)
		public decimal UnitCost { get; set; } //money
		public string Description { get; set; } //nvarchar(3800)
		public virtual Category Category { get; set; }
		public virtual ICollection<Review> Reviews { get; set; }
		public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
	}
}
