using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap() : this("dbo")
        {
        }
        
        public StudentMap(string schema)
        {
            ToTable(schema + ".Student");
            HasKey(x => x.Id);
            
            Property(x => x.Id).HasColumnName("StudentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(50);
            Property(x => x.FirstMidName).HasColumnName("FirstMidName").IsRequired().HasMaxLength(50);
            Property(x => x.EnrollmentDate).HasColumnName("EnrollmentDate").IsRequired();
        }
    }
}
