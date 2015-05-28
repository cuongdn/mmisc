using Blogging.DbModel.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Blogging.DbModel.Mapping
{
    public class AnswerMap : EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            ToTable("Answer");

            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption((DatabaseGeneratedOption?)DatabaseGeneratedOption.Identity);
            Property(x => x.Description).IsRequired();
            Property(x => x.Vote);
        }
    }
}