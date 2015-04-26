using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Cs.DbModel.Entities;

namespace Cs.DbModel.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            ToTable("Student");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("StudentId").IsRequired();
            Property(x => x.LastName).IsRequired();
            Property(x => x.FirstMidName).IsRequired();
            Property(x => x.EnrollmentDate).IsRequired();
            HasMany(x => x.Enrollments)
                .WithRequired(x => x.Student)
                .WillCascadeOnDelete(true);
        }
    }

    public class EnrollmentMap : EntityTypeConfiguration<Enrollment>
    {
        public EnrollmentMap()
        {
            ToTable("Enrollment");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("EnrollmentId").IsRequired();
            Property(x => x.Grade);
        }
    }

    public class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap()
        {
            ToTable("Course");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("CourseId").IsRequired();
            Property(x => x.Title).IsRequired();
            Property(x => x.Credits).IsRequired();

            HasRequired(x => x.Department);

            HasMany(x => x.Enrollments)
                .WithRequired(x => x.Course)
                .WillCascadeOnDelete(true);

            //HasMany(x => x.Instructors)
            //    .WithMany(x => x.Courses)
            //    .Map(x => x.MapLeftKey("CourseId")
            //        .MapRightKey("InstructorId")
            //        .ToTable("CourseInstructor"));
        }
    }

    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            ToTable("Department");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("DepartmentId").IsRequired();
            Property(x => x.Budget).IsRequired();
            Property(x => x.StartDate).IsRequired();
            HasRequired(x => x.Administrator);
        }
    }

    public class InstructorMap : EntityTypeConfiguration<Instructor>
    {
        public InstructorMap()
        {
            ToTable("Instructor");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("InstructorId").IsRequired();
            Property(x => x.LastName).IsRequired();
            Property(x => x.FirstMidName).IsRequired();
            Property(x => x.HireDate).IsRequired();
            HasOptional(x => x.OfficeAssignment)
                .WithRequired(x => x.Instructor);

            //HasMany(x => x.Courses)
            //   .WithMany(x => x.Instructors)
            //   .Map(x => x.MapLeftKey("InstructorId")
            //       .MapRightKey("CourseId")
            //       .ToTable("CourseInstructor"));
        }
    }

    public class OfficeAssignmentMap : EntityTypeConfiguration<OfficeAssignment>
    {
        public OfficeAssignmentMap()
        {
            ToTable("OfficeAssignment");
            HasKey(x => x.Id);
            Property(x => x.Location).IsRequired();
        }
    }

    public class CourseInstructorMap : EntityTypeConfiguration<CourseInstructor>
    {
        public CourseInstructorMap()
        {
            ToTable("CourseInstructor");
            HasKey(x => x.Id);
            HasRequired(x => x.Course)
                .WithMany(x => x.CourseInstructors)
                .WillCascadeOnDelete(true);
            HasRequired(x => x.Instructor)
             .WithMany(x => x.CourseInstructors).WillCascadeOnDelete(true);
            HasRequired(x => x.Course);
        }
    }
}
