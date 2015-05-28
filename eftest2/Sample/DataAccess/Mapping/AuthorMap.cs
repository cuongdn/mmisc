using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Mapping
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap() : this("dbo")
        {
        }
        
        public AuthorMap(string schema)
        {
            ToTable(schema + ".Author");
            HasKey(x => x.Id);
            
            Property(x => x.Id).HasColumnName("AuthorId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
        }
    }
}
