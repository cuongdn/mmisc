using System;
using Core.Business.Common;
using Core.Business.Utils;
using Mms.DataAccess.Entities;

namespace Mms.Business.Edit
{
    public class AlbumEdit : ModelEditBase
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
        
        public static AlbumEdit New()
        {
            return ModelHelper.NewModelObject<AlbumEdit>();
        }
        
        public static AlbumEdit Get(int id)
        {
            return ObjectUtil.GetEdit<AlbumEdit, Album>(id);
        }
        
        public override bool Upsert(bool forceUpdate = false)
        {
            return ObjectUtil.Upsert<AlbumEdit, Album>(this, forceUpdate);
        }
        
        public override bool Delete()
        {
            return ObjectUtil.Delete<AlbumEdit, Album>(this);
        }
    }
}
