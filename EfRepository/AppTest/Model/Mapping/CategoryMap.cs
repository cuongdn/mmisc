using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AppTest.Mapping
{
	public partial class CategoryMap : EntityTypeConfiguration<Category>
	{
		public CategoryMap()
		{
			// Primary Key
			this.HasKey(t => t.CategoryID);
			// Properties
			this.Property(t => t.CategoryName)
			    .HasMaxLength(50);
			// Table & Column Mappings
			this.ToTable("Categories");
			this.Property(t => t.CategoryID).HasColumnName("CategoryID");
			this.Property(t => t.CategoryName).HasColumnName("CategoryName");
			// Relationships
		}
	}
}
