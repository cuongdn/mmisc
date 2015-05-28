using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Sample.DataAccess.Entities
{
    public class Author : Entity<int>
    {
        public override int Id
        {
            get { return AuthorId; }
            set { AuthorId = value; }
        }
        
        public int AuthorId { get; set; } // AuthorId (Primary key)
        public string Name { get; set; } // Name
        
    }
}
