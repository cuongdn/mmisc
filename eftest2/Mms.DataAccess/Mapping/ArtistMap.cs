using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Mms.DataAccess.Entities;

namespace Mms.DataAccess.Mapping
{
    public class ArtistMap : EntityTypeConfiguration<Artist>
    {
        public ArtistMap()
        {
            ToTable("dbo.Artist");
            HasKey(x => x.Id);
            
            Property(x => x.Id).HasColumnName("ArtistId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsOptional().HasMaxLength(120);
        }
    }
}
