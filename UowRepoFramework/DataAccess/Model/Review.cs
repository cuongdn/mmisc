using Repository.Pattern.Ef6;

namespace DataAccess.Model
{
    public class Review : Entity
    {
        public int ReviewId { get; set; } //int
        public int ProductId { get; set; } //int
        public string CustomerName { get; set; } //nvarchar(50)
        public string CustomerEmail { get; set; } //nvarchar(50)
        public int Rating { get; set; } //int
        public string Comments { get; set; } //nvarchar(3850)
        public virtual Product Product { get; set; }
    }
}