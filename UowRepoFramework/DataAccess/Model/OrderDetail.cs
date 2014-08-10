using Repository.Pattern.Ef6;

namespace DataAccess.Model
{
    public class OrderDetail : Entity
    {
        public int OrderId { get; set; } //int
        public int ProductId { get; set; } //int
        public int Quantity { get; set; } //int
        public decimal UnitCost { get; set; } //money
        public virtual Order Order { get; set; }
    }
}