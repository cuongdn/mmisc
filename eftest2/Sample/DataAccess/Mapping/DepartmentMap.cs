using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Mapping
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap() : this("dbo")
        {
        }
        
        public DepartmentMap(string schema)
        {
            ToTable(schema + ".Department");
            HasKey(x => x.Id);
            
            Property(x => x.Id).HasColumnName("DepartmentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            Property(x => x.Budget).HasColumnName("Budget").IsRequired().HasPrecision(19,4);
            Property(x => x.StartDate).HasColumnName("StartDate").IsRequired();
            Property(x => x.InstructorId).HasColumnName("InstructorId").IsOptional();
            
            HasOptional(a => a.Instructor).WithMany(b => b.Departments).HasForeignKey(c => c.InstructorId); // FK_Department_Instructor
        }
    }
}
