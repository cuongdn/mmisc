using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Mms.DataAccess.Entities
{
    public class Artist : Entity<int>
    {
        public string Name { get; set; } // Name
        
        public virtual ICollection<Album> Albums { get; set; } // Album.FK__Album__ArtistId__276EDEB3
        
        public Artist()
        {
            Albums = new List<Album>();
        }
    }
}
