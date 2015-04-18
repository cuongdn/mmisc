using Core.DataAccess.Entities;

namespace Blogging.DbModel.Entities
{
    public class Blog : AuditableEntity<int>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string AuthorId { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}