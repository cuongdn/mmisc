using System.Collections.Generic;
using Repository.Pattern.Ef6;

namespace DataAccess.Model
{
    public class Category : Entity
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public int CategoryId { get; set; } //int
        public string CategoryName { get; set; } //nvarchar(50)
        public virtual ICollection<Product> Products { get; set; }
    }
}