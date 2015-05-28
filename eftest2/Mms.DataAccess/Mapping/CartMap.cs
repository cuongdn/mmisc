using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Mms.DataAccess.Entities;

namespace Mms.DataAccess.Mapping
{
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            ToTable("dbo.Cart");
            HasKey(x => x.Id);
            
            Property(x => x.Id).HasColumnName("RecordId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CartId).HasColumnName("CartId").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.AlbumId).HasColumnName("AlbumId").IsRequired();
            Property(x => x.Count).HasColumnName("Count").IsRequired();
            Property(x => x.DateCreated).HasColumnName("DateCreated").IsRequired();
            
            HasRequired(a => a.Album).WithMany(b => b.Carts).HasForeignKey(c => c.AlbumId); // FK_Cart_Album
        }
    }
}
