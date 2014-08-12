using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Model.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            HasKey(t => t.CategoryId);
            // Properties
            Property(t => t.CategoryName)
                .HasMaxLength(50);
            // Table & Column Mappings
            ToTable("Categories");
            Property(t => t.CategoryId).HasColumnName("CategoryID");
            Property(t => t.CategoryName).HasColumnName("CategoryName");
            // Relationships
        }
    }
}