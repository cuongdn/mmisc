using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Mms.DataAccess.Entities;

namespace Mms.DataAccess.Mapping
{
    public class GenreMap : EntityTypeConfiguration<Genre>
    {
        public GenreMap()
        {
            ToTable("dbo.Genre");
            HasKey(x => x.Id);
            
            Property(x => x.Id).HasColumnName("GenreId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(120);
            Property(x => x.Description).HasColumnName("Description").IsOptional().HasMaxLength(4000);
        }
    }
}
