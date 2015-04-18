using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Blogging.DbModel.Entities;

namespace Blogging.DbModel.Mapping
{
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            ToTable("Blogs");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).IsRequired();
            Property(x => x.Body).IsRequired();
            Property(x => x.CreatedDate).HasColumnName("CreatedAt").IsRequired();
            Property(x => x.UpdatedDate).HasColumnName("UpdatedAt");
            Property(x => x.AuthorId);
            HasRequired(x => x.Category)
                .WithMany(x => x.Blogs)
                .WillCascadeOnDelete(true);
        }
    }
}