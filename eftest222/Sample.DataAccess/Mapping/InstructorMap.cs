using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Mapping
{
    public class InstructorMap : EntityTypeConfiguration<Instructor>
    {
        public InstructorMap(string schema = "dbo")
        {
            ToTable(schema + ".Instructor");
            HasKey(x => x.InstructorId);
            
            Property(x => x.InstructorId).HasColumnName("InstructorId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(50);
            Property(x => x.FirstMidName).HasColumnName("FirstMidName").IsRequired().HasMaxLength(50);
            Property(x => x.HireDate).HasColumnName("HireDate").IsRequired();
        }
    }
}
