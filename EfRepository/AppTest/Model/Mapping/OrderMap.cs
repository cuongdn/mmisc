using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AppTest.Mapping
{
	public partial class OrderMap : EntityTypeConfiguration<Order>
	{
		public OrderMap()
		{
			// Primary Key
			this.HasKey(t => t.OrderID);
			// Properties
			// Table & Column Mappings
			this.ToTable("Orders");
			this.Property(t => t.OrderID).HasColumnName("OrderID");
			this.Property(t => t.CustomerID).HasColumnName("CustomerID");
			this.Property(t => t.OrderDate).HasColumnName("OrderDate");
			this.Property(t => t.ShipDate).HasColumnName("ShipDate");
			// Relationships
			this.HasRequired(t => t.Customer)
			    .WithMany(t => t.Orders)
			    .HasForeignKey(d => d.CustomerID);
		}
	}
}
