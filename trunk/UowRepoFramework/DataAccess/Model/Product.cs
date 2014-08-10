using System.Collections.Generic;
using Repository.Pattern.Ef6;

namespace DataAccess.Model
{
    public class Product : Entity
    {
        public Product()
        {
            Reviews = new List<Review>();
            ShoppingCarts = new List<ShoppingCart>();
        }

        public int ProductId { get; set; } //int
        public int CategoryId { get; set; } //int
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