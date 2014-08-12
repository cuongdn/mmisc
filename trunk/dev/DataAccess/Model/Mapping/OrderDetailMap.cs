using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Model.Mapping
{
    public class OrderDetailMap : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMap()
        {
            // Primary Key
            HasKey(t => new {t.OrderId, t.ProductId});
            // Properties
            Property(t => t.OrderId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Table & Column Mappings
            ToTable("OrderDetails");
            Property(t => t.OrderId).HasColumnName("OrderID");
            Property(t => t.ProductId).HasColumnName("ProductID");
            Property(t => t.Quantity).HasColumnName("Quantity");
            Property(t => t.UnitCost).HasColumnName("UnitCost");
            // Relationships
            HasRequired(t => t.Order)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(d => d.OrderId);
        }
    }
}