using System;
using Core.Business.Common;
using Core.Business.Utils;
using Mms.DataAccess.Entities;

namespace Mms.Business.Edit
{
    public class CartEdit : ModelEditBase
    {
        public override object IdValue
        {
            get { return Id; }
        }
        
        public int Id { get; set; }
        public string CartId { get; set; } // CartId
        public int AlbumId { get; set; } // AlbumId
        public int Count { get; set; } // Count
        public DateTime DateCreated { get; set; } // DateCreated
        
        public static CartEdit New()
        {
            return ModelHelper.NewModelObject<CartEdit>();
        }
        
        public static CartEdit Get(int id)
        {
            return ObjectUtil.GetEdit<CartEdit, Cart>(id);
        }
        
        public override bool Upsert(bool forceUpdate = false)
        {
            return ObjectUtil.Upsert<CartEdit, Cart>(this, forceUpdate);
        }
        
        public override bool Delete()
        {
            return ObjectUtil.Delete<CartEdit, Cart>(this);
        }
    }
}
