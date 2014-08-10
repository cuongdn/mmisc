using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Model.Mapping
{
    public class ShoppingCartMap : EntityTypeConfiguration<ShoppingCart>
    {
        public ShoppingCartMap()
        {
            // Primary Key
            HasKey(t => t.RecordId);
            // Properties
            Property(t => t.CartId)
                .HasMaxLength(50);
            // Table & Column Mappings
            ToTable("ShoppingCart");
            Property(t => t.RecordId).HasColumnName("RecordID");
            Property(t => t.CartId).HasColumnName("CartID");
            Property(t => t.Quantity).HasColumnName("Quantity");
            Property(t => t.ProductId).HasColumnName("ProductID");
            Property(t => t.DateCreated).HasColumnName("DateCreated");
            // Relationships
            HasRequired(t => t.Product)
                .WithMany(t => t.ShoppingCarts)
                .HasForeignKey(d => d.ProductId);
        }
    }
}