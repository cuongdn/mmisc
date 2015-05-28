using System.Collections.Generic;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Mms.DataAccess.Entities;
using Mms.DataAccess.Repositories;

namespace Mms.Business.Preview
{
    public class AlbumPreview : ModelBase
    {
        public override object IdValue
        {
            get { return Id; }
        }
        
        public int Id { get; set; }
        public int GenreId { get; set; } // GenreId
        public int ArtistId { get; set; } // ArtistId
        public string Title { get; set; } // Title
        public decimal Price { get; set; } // Price
        public string AlbumArtUrl { get; set; } // AlbumArtUrl
        
        public static IList<AlbumPreview> GetList()
        {
            var repo = UowFactory.Get().Repository<AlbumRepository>();
            return ModelHelper.FetchList<AlbumPreview, Album>(repo.GetAll());
        }
    }
}
