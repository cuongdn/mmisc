using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Mapping
{
    public class OfficeAssignmentMap : EntityTypeConfiguration<OfficeAssignment>
    {
        public OfficeAssignmentMap() : this("dbo")
        {
        }
        
        public OfficeAssignmentMap(string schema)
        {
            ToTable(schema + ".OfficeAssignment");
            HasKey(x => x.Id);
            
            Property(x => x.Id).HasColumnName("InstructorId").IsRequired();
            Property(x => x.Location).HasColumnName("Location").IsRequired().HasMaxLength(50);
            
            HasRequired(a => a.Instructor).WithOptional(b => b.OfficeAssignment); // FK_OfficeAssignment_Instructor
        }
    }
}
