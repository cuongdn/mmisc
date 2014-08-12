using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Model.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            HasKey(t => t.CustomerID);
            // Properties
            Property(t => t.FullName)
                .HasMaxLength(50);
            Property(t => t.EmailAddress)
                .HasMaxLength(50);
            Property(t => t.Password)
                .HasMaxLength(50);
            // Table & Column Mappings
            ToTable("Customers");
            Property(t => t.CustomerID).HasColumnName("CustomerID");
            Property(t => t.FullName).HasColumnName("FullName");
            Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            Property(t => t.Password).HasColumnName("Password");
            // Relationships
        }
    }
}