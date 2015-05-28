using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Mapping
{
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap(string schema = "dbo")
        {
            ToTable(schema + ".Log");
            HasKey(x => x.Id);
            
            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Date).HasColumnName("Date").IsOptional();
            Property(x => x.Thread).HasColumnName("Thread").IsOptional().HasMaxLength(50);
            Property(x => x.Level).HasColumnName("Level").IsOptional().HasMaxLength(50);
            Property(x => x.Logger).HasColumnName("Logger").IsOptional().HasMaxLength(255);
            Property(x => x.Message).HasColumnName("Message").IsOptional().HasMaxLength(4000);
            Property(x => x.Exception).HasColumnName("Exception").IsOptional().HasMaxLength(2000);
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
            Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").IsOptional();
        }
    }
}
