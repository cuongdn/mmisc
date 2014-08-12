using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Model.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            HasKey(t => t.ProductId);
            // Properties
            Property(t => t.ModelNumber)
                .HasMaxLength(50);
            Property(t => t.ModelName)
                .HasMaxLength(50);
            Property(t => t.ProductImage)
                .HasMaxLength(50);
            Property(t => t.Description)
                .HasMaxLength(3800);
            // Table & Column Mappings
            ToTable("Products");
            Property(t => t.ProductId).HasColumnName("ProductID");
            Property(t => t.CategoryId).HasColumnName("CategoryID");
            Property(t => t.ModelNumber).HasColumnName("ModelNumber");
            Property(t => t.ModelName).HasColumnName("ModelName");
            Property(t => t.ProductImage).HasColumnName("ProductImage");
            Property(t => t.UnitCost).HasColumnName("UnitCost");
            Property(t => t.Description).HasColumnName("Description");
            // Relationships
            HasRequired(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.CategoryId);
        }
    }
}