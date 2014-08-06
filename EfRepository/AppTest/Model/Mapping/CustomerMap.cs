using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AppTest.Mapping
{
	public partial class CustomerMap : EntityTypeConfiguration<Customer>
	{
		public CustomerMap()
		{
			// Primary Key
			this.HasKey(t => t.CustomerID);
			// Properties
			this.Property(t => t.FullName)
			    .HasMaxLength(50);
			this.Property(t => t.EmailAddress)
			    .HasMaxLength(50);
			this.Property(t => t.Password)
			    .HasMaxLength(50);
			// Table & Column Mappings
			this.ToTable("Customers");
			this.Property(t => t.CustomerID).HasColumnName("CustomerID");
			this.Property(t => t.FullName).HasColumnName("FullName");
			this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
			this.Property(t => t.Password).HasColumnName("Password");
			// Relationships
		}
	}
}
