using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Sample.DataAccess.Entities
{
    public class Book : Entity<int>
    {
        public string Title { get; set; } // Title
        public decimal Price { get; set; } // Price
        public string Genre { get; set; } // Genre
        public string PublishDate { get; set; } // PublishDate
        public string Description { get; set; } // Description
        public int AuthorId { get; set; } // AuthorId
        
    }
}
