using Core.DataAccess.Entities;

namespace Blogging.DbModel.Entities
{
    public class Answer : Entity<int>
    {
        public string Description { get; set; }
        public int? Vote { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}