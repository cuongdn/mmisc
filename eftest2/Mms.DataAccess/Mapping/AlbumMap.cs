using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Mms.DataAccess.Entities;

namespace Mms.DataAccess.Mapping
{
    public class AlbumMap : EntityTypeConfiguration<Album>
    {
        public AlbumMap()
        {
            ToTable("dbo.Album");
            HasKey(x => x.Id);
            
            Property(x => x.Id).HasColumnName("AlbumId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.GenreId).HasColumnName("GenreId").IsRequired();
            Property(x => x.ArtistId).HasColumnName("ArtistId").IsRequired();
            Property(x => x.Title).HasColumnName("Title").IsRequired().HasMaxLength(160);
            Property(x => x.Price).HasColumnName("Price").IsRequired().HasPrecision(10,2);
            Property(x => x.AlbumArtUrl).HasColumnName("AlbumArtUrl").IsOptional().HasMaxLength(1024);
            
            HasRequired(a => a.Genre).WithMany(b => b.Albums).HasForeignKey(c => c.GenreId); // FK_Album_Genre
            HasRequired(a => a.Artist).WithMany(b => b.Albums).HasForeignKey(c => c.ArtistId); // FK__Album__ArtistId__276EDEB3
        }
    }
}
