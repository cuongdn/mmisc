using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Mapping
{
    public class OfficeAssignmentMap : EntityTypeConfiguration<OfficeAssignment>
    {
        public OfficeAssignmentMap(string schema = "dbo")
        {
            ToTable(schema + ".OfficeAssignment");
            HasKey(x => x.InstructorId);
            
            Property(x => x.InstructorId).HasColumnName("InstructorId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Location).HasColumnName("Location").IsRequired().HasMaxLength(50);
            
            HasRequired(a => a.Instructor).WithOptional(b => b.OfficeAssignment); // FK_OfficeAssignment_Instructor
        }
    }
}
