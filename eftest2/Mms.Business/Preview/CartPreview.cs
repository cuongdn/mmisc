using System;
using System.Collections.Generic;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Mms.DataAccess.Entities;
using Mms.DataAccess.Repositories;

namespace Mms.Business.Preview
{
    public class CartPreview : ModelBase
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
        
        public static IList<CartPreview> GetList()
        {
            var repo = UowFactory.Get().Repository<CartRepository>();
            return ModelHelper.FetchList<CartPreview, Cart>(repo.GetAll());
        }
    }
}
