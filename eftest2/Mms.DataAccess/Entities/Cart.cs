using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Mms.DataAccess.Entities
{
    public class Cart : Entity<int>
    {
        public string CartId { get; set; } // CartId
        public int AlbumId { get; set; } // AlbumId
        public int Count { get; set; } // Count
        public DateTime DateCreated { get; set; } // DateCreated
        
        public virtual Album Album { get; set; } // FK_Cart_Album
    }
}
