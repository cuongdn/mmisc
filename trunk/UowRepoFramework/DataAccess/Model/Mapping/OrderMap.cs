using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Model.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            HasKey(t => t.OrderId);
            // Properties
            // Table & Column Mappings
            ToTable("Orders");
            Property(t => t.OrderId).HasColumnName("OrderID");
            Property(t => t.CustomerId).HasColumnName("CustomerID");
            Property(t => t.OrderDate).HasColumnName("OrderDate");
            Property(t => t.ShipDate).HasColumnName("ShipDate");
            // Relationships
            HasRequired(t => t.Customer)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.CustomerId);
        }
    }
}