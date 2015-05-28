using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Mapping
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap(string schema = "dbo")
        {
            ToTable(schema + ".Book");
            HasKey(x => x.BookId);
            
            Property(x => x.BookId).HasColumnName("BookId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).HasColumnName("Title").IsRequired().HasMaxLength(50);
            Property(x => x.Price).HasColumnName("Price").IsRequired().HasPrecision(19,4);
            Property(x => x.Genre).HasColumnName("Genre").IsRequired().HasMaxLength(50);
            Property(x => x.PublishDate).HasColumnName("PublishDate").IsRequired().HasMaxLength(50);
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasMaxLength(100);
            Property(x => x.AuthorId).HasColumnName("AuthorId").IsRequired();
        }
    }
}
