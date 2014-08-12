using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Model.Mapping
{
    public class ReviewMap : EntityTypeConfiguration<Review>
    {
        public ReviewMap()
        {
            // Properties
            Property(t => t.CustomerName)
                .HasMaxLength(50);
            Property(t => t.CustomerEmail)
                .HasMaxLength(50);
            Property(t => t.Comments)
                .HasMaxLength(3850);
            // Table & Column Mappings
            ToTable("Reviews");
            Property(t => t.ReviewId).HasColumnName("ReviewID");
            Property(t => t.ProductId).HasColumnName("ProductID");
            Property(t => t.CustomerName).HasColumnName("CustomerName");
            Property(t => t.CustomerEmail).HasColumnName("CustomerEmail");
            Property(t => t.Rating).HasColumnName("Rating");
            Property(t => t.Comments).HasColumnName("Comments");
            // Relationships
            HasRequired(t => t.Product)
                .WithMany(t => t.Reviews)
                .HasForeignKey(d => d.ProductId);
        }
    }
}