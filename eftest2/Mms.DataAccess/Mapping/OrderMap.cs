using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Mms.DataAccess.Entities;

namespace Mms.DataAccess.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("dbo.Order");
            HasKey(x => x.Id);
            
            Property(x => x.Id).HasColumnName("OrderId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderDate).HasColumnName("OrderDate").IsRequired();
            Property(x => x.Username).HasColumnName("Username").IsOptional().HasMaxLength(256);
            Property(x => x.FirstName).HasColumnName("FirstName").IsOptional().HasMaxLength(160);
            Property(x => x.LastName).HasColumnName("LastName").IsOptional().HasMaxLength(160);
            Property(x => x.Address).HasColumnName("Address").IsOptional().HasMaxLength(70);
            Property(x => x.City).HasColumnName("City").IsOptional().HasMaxLength(40);
            Property(x => x.State).HasColumnName("State").IsOptional().HasMaxLength(40);
            Property(x => x.PostalCode).HasColumnName("PostalCode").IsOptional().HasMaxLength(10);
            Property(x => x.Country).HasColumnName("Country").IsOptional().HasMaxLength(40);
            Property(x => x.Phone).HasColumnName("Phone").IsOptional().HasMaxLength(24);
            Property(x => x.Email).HasColumnName("Email").IsOptional().HasMaxLength(160);
            Property(x => x.Total).HasColumnName("Total").IsRequired().HasPrecision(10,2);
        }
    }
}
