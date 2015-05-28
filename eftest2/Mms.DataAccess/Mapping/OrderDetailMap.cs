using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Mms.DataAccess.Entities;

namespace Mms.DataAccess.Mapping
{
    public class OrderDetailMap : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetail");
            HasKey(x => x.Id);
            
            Property(x => x.Id).HasColumnName("OrderDetailId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderId).HasColumnName("OrderId").IsRequired();
            Property(x => x.AlbumId).HasColumnName("AlbumId").IsRequired();
            Property(x => x.Quantity).HasColumnName("Quantity").IsRequired();
            Property(x => x.UnitPrice).HasColumnName("UnitPrice").IsRequired().HasPrecision(10,2);
            
            HasRequired(a => a.Order).WithMany(b => b.OrderDetails).HasForeignKey(c => c.OrderId); // FK__InvoiceLi__Invoi__2F10007B
            HasRequired(a => a.Album).WithMany(b => b.OrderDetails).HasForeignKey(c => c.AlbumId); // FK_InvoiceLine_Album
        }
    }
}
