using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Mapping
{
    public class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap() : this("dbo")
        {
        }
        
        public CourseMap(string schema)
        {
            ToTable(schema + ".Course");
            HasKey(x => x.Id);
            
            Property(x => x.Id).HasColumnName("CourseId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).HasColumnName("Title").IsRequired().HasMaxLength(50);
            Property(x => x.Credits).HasColumnName("Credits").IsRequired();
            Property(x => x.DepartmentId).HasColumnName("DepartmentId").IsRequired();
            Property(x => x.RowVersion).HasColumnName("RowVersion").IsRequired().IsFixedLength().HasMaxLength(8).IsRowVersion();
            
            HasRequired(a => a.Department).WithMany(b => b.Courses).HasForeignKey(c => c.DepartmentId); // FK_Course_Department
            HasMany(t => t.Instructors).WithMany(t => t.Courses).Map(m => 
            {
                m.ToTable("CourseInstructor", schema);
                m.MapLeftKey("CourseId");
                m.MapRightKey("InstructorId");
            });
        }
    }
}
