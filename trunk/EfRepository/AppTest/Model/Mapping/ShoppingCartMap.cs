using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AppTest.Mapping
{
	public partial class ShoppingCartMap : EntityTypeConfiguration<ShoppingCart>
	{
		public ShoppingCartMap()
		{
			// Primary Key
			this.HasKey(t => t.RecordID);
			// Properties
			this.Property(t => t.CartID)
			    .HasMaxLength(50);
			// Table & Column Mappings
			this.ToTable("ShoppingCart");
			this.Property(t => t.RecordID).HasColumnName("RecordID");
			this.Property(t => t.CartID).HasColumnName("CartID");
			this.Property(t => t.Quantity).HasColumnName("Quantity");
			this.Property(t => t.ProductID).HasColumnName("ProductID");
			this.Property(t => t.DateCreated).HasColumnName("DateCreated");
			// Relationships
			this.HasRequired(t => t.Product)
			    .WithMany(t => t.ShoppingCarts)
			    .HasForeignKey(d => d.ProductID);
		}
	}
}
