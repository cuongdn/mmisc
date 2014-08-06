using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AppTest.Mapping
{
	public partial class ProductMap : EntityTypeConfiguration<Product>
	{
		public ProductMap()
		{
			// Primary Key
			this.HasKey(t => t.ProductID);
			// Properties
			this.Property(t => t.ModelNumber)
			    .HasMaxLength(50);
			this.Property(t => t.ModelName)
			    .HasMaxLength(50);
			this.Property(t => t.ProductImage)
			    .HasMaxLength(50);
			this.Property(t => t.Description)
			    .HasMaxLength(3800);
			// Table & Column Mappings
			this.ToTable("Products");
			this.Property(t => t.ProductID).HasColumnName("ProductID");
			this.Property(t => t.CategoryID).HasColumnName("CategoryID");
			this.Property(t => t.ModelNumber).HasColumnName("ModelNumber");
			this.Property(t => t.ModelName).HasColumnName("ModelName");
			this.Property(t => t.ProductImage).HasColumnName("ProductImage");
			this.Property(t => t.UnitCost).HasColumnName("UnitCost");
			this.Property(t => t.Description).HasColumnName("Description");
			// Relationships
			this.HasRequired(t => t.Category)
			    .WithMany(t => t.Products)
			    .HasForeignKey(d => d.CategoryID);
		}
	}
}
