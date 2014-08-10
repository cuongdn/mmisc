using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Repository.Pattern.Ef6;

namespace DataAccess.Model
{
    //[Validator(typeof(CategoryValidator))]
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