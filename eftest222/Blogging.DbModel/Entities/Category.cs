using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Blogging.DbModel.Entities
{
    public class Category : Entity<int>
    {
        public Category()
        {
            Blogs = new List<Blog>();
        }

        public string CategoryName { get; set; }
        public virtual IList<Blog> Blogs { get; set; }
    }
}
