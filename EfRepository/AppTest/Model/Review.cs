using System;
using Core;

namespace AppTest
{
	public partial class Review : Entity
	{
		public Review()
		{
		}
		public int ReviewID { get; set; } //int
		public int ProductID { get; set; } //int
		public string CustomerName { get; set; } //nvarchar(50)
		public string CustomerEmail { get; set; } //nvarchar(50)
		public int Rating { get; set; } //int
		public string Comments { get; set; } //nvarchar(3850)
		public virtual Product Product { get; set; }
	}
}
