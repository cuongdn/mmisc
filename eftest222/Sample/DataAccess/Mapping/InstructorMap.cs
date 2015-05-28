using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Mapping
{
    public class InstructorMap : EntityTypeConfiguration<Instructor>
    {
        public InstructorMap() : this("dbo")
        {
        }
        
        public InstructorMap(string schema)
        {
            ToTable(schema + ".Instructor");
            HasKey(x => x.Id);
            
            Property(x => x.Id).HasColumnName("InstructorId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(50);
            Property(x => x.FirstMidName).HasColumnName("FirstMidName").IsRequired().HasMaxLength(50);
            Property(x => x.HireDate).HasColumnName("HireDate").IsRequired();
        }
    }
}
