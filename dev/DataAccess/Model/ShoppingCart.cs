using RepositoryPattern.Ef;
using System;

namespace DataAccess.Model
{
    public class ShoppingCart : Entity
    {
        public int RecordId { get; set; } //int
        public string CartId { get; set; } //nvarchar(50)
        public int Quantity { get; set; } //int
        public int ProductId { get; set; } //int
        public DateTime DateCreated { get; set; } //datetime
        public virtual Product Product { get; set; }
    }
}