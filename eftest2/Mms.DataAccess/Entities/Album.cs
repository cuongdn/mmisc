using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Mms.DataAccess.Entities
{
    public class Album : Entity<int>
    {
        public int GenreId { get; set; } // GenreId
        public int ArtistId { get; set; } // ArtistId
        public string Title { get; set; } // Title
        public decimal Price { get; set; } // Price
        public string AlbumArtUrl { get; set; } // AlbumArtUrl
        
        public virtual ICollection<Cart> Carts { get; set; } // Cart.FK_Cart_Album
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } // OrderDetail.FK_InvoiceLine_Album
        public virtual Artist Artist { get; set; } // FK__Album__ArtistId__276EDEB3
        public virtual Genre Genre { get; set; } // FK_Album_Genre
        
        public Album()
        {
            AlbumArtUrl = "N'/Content/Images/placeholder.gif'";
            Carts = new List<Cart>();
            OrderDetails = new List<OrderDetail>();
        }
    }
}
