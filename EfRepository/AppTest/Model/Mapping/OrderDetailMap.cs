using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AppTest.Mapping
{
	public partial class OrderDetailMap : EntityTypeConfiguration<OrderDetail>
	{
		public OrderDetailMap()
		{
			// Primary Key
			this.HasKey(t => new { t.OrderID, t.ProductID });
			// Properties
			this.Property(t => t.OrderID)
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			this.Property(t => t.ProductID)
			    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			// Table & Column Mappings
			this.ToTable("OrderDetails");
			this.Property(t => t.OrderID).HasColumnName("OrderID");
			this.Property(t => t.ProductID).HasColumnName("ProductID");
			this.Property(t => t.Quantity).HasColumnName("Quantity");
			this.Property(t => t.UnitCost).HasColumnName("UnitCost");
			// Relationships
			this.HasRequired(t => t.Order)
			    .WithMany(t => t.OrderDetails)
			    .HasForeignKey(d => d.OrderID);
		}
	}
}
