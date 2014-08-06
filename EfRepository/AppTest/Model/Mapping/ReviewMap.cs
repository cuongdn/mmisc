using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AppTest.Mapping
{
	public partial class ReviewMap : EntityTypeConfiguration<Review>
	{
		public ReviewMap()
		{
			// Properties
			this.Property(t => t.CustomerName)
			    .HasMaxLength(50);
			this.Property(t => t.CustomerEmail)
			    .HasMaxLength(50);
			this.Property(t => t.Comments)
			    .HasMaxLength(3850);
			// Table & Column Mappings
			this.ToTable("Reviews");
			this.Property(t => t.ReviewID).HasColumnName("ReviewID");
			this.Property(t => t.ProductID).HasColumnName("ProductID");
			this.Property(t => t.CustomerName).HasColumnName("CustomerName");
			this.Property(t => t.CustomerEmail).HasColumnName("CustomerEmail");
			this.Property(t => t.Rating).HasColumnName("Rating");
			this.Property(t => t.Comments).HasColumnName("Comments");
			// Relationships
			this.HasRequired(t => t.Product)
			    .WithMany(t => t.Reviews)
			    .HasForeignKey(d => d.ProductID);
		}
	}
}
