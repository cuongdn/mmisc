using System.Collections.Generic;
using Repository.Pattern.Ef6;

namespace DataAccess.Model
{
    public class Customer : Entity
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        public int CustomerID { get; set; } //int
        public string FullName { get; set; } //nvarchar(50)
        public string EmailAddress { get; set; } //nvarchar(50)
        public string Password { get; set; } //nvarchar(50)
        public virtual ICollection<Order> Orders { get; set; }
    }
}