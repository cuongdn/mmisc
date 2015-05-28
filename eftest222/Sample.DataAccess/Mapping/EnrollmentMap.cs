using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Mapping
{
    public class EnrollmentMap : EntityTypeConfiguration<Enrollment>
    {
        public EnrollmentMap(string schema = "dbo")
        {
            ToTable(schema + ".Enrollment");
            HasKey(x => x.EnrollmentId);
            
            Property(x => x.EnrollmentId).HasColumnName("EnrollmentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CourseId).HasColumnName("CourseId").IsRequired();
            Property(x => x.StudentId).HasColumnName("StudentId").IsRequired();
            Property(x => x.Grade).HasColumnName("Grade").IsOptional();
            
            HasRequired(a => a.Course).WithMany(b => b.Enrollments).HasForeignKey(c => c.CourseId); // FK_Enrollment_Course
            HasRequired(a => a.Student).WithMany(b => b.Enrollments).HasForeignKey(c => c.StudentId); // FK_Enrollment_Student
        }
    }
}
