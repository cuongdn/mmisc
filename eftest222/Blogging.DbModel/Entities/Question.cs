using Core.DataAccess.Entities;
using System.Collections.Generic;

namespace Blogging.DbModel.Entities
{
    public class Question : AuditableEntity<int>
    {
        public Question()
        {
            Answers = new List<Answer>();
        }

        public string Title { get; set; }
        public virtual IList<Answer> Answers { get; set; }
    }
}
