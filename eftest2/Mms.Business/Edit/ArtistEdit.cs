using System;
using Core.Business.Common;
using Core.Business.Utils;
using Mms.DataAccess.Entities;

namespace Mms.Business.Edit
{
    public class ArtistEdit : ModelEditBase
    {
        public override object IdValue
        {
            get { return Id; }
        }
        
        public int Id { get; set; }
        public string Name { get; set; } // Name
        
        public static ArtistEdit New()
        {
            return ModelHelper.NewModelObject<ArtistEdit>();
        }
        
        public static ArtistEdit Get(int id)
        {
            return ObjectUtil.GetEdit<ArtistEdit, Artist>(id);
        }
        
        public override bool Upsert(bool forceUpdate = false)
        {
            return ObjectUtil.Upsert<ArtistEdit, Artist>(this, forceUpdate);
        }
        
        public override bool Delete()
        {
            return ObjectUtil.Delete<ArtistEdit, Artist>(this);
        }
    }
}
