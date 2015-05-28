using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Mms.DataAccess.Entities
{
    public class Genre : Entity<int>
    {
        public string Name { get; set; } // Name
        public string Description { get; set; } // Description
        
        public virtual ICollection<Album> Albums { get; set; } // Album.FK_Album_Genre
        
        public Genre()
        {
            Albums = new List<Album>();
        }
    }
}
