using System;
using Core.Business.Common;
using Core.Business.Utils;
using Mms.DataAccess.Entities;

namespace Mms.Business.Edit
{
    public class GenreEdit : ModelEditBase
    {
        public override object IdValue
        {
            get { return Id; }
        }
        
        public int Id { get; set; }
        public string Name { get; set; } // Name
        public string Description { get; set; } // Description
        
        public static GenreEdit New()
        {
            return ModelHelper.NewModelObject<GenreEdit>();
        }
        
        public static GenreEdit Get(int id)
        {
            return ObjectUtil.GetEdit<GenreEdit, Genre>(id);
        }
        
        public override bool Upsert(bool forceUpdate = false)
        {
            return ObjectUtil.Upsert<GenreEdit, Genre>(this, forceUpdate);
        }
        
        public override bool Delete()
        {
            return ObjectUtil.Delete<GenreEdit, Genre>(this);
        }
    }
}
