using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Sample.DataAccess.Entities
{
    public class Author : Entity<int>
    {
        public string Name { get; set; } // Name
        
    }
}
