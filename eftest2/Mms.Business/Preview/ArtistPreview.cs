﻿using System.Collections.Generic;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Mms.DataAccess.Entities;
using Mms.DataAccess.Repositories;

namespace Mms.Business.Preview
{
    public class ArtistPreview : ModelBase
    {
        public override object IdValue
        {
            get { return Id; }
        }
        
        public int Id { get; set; }
        public string Name { get; set; } // Name
        
        public static IList<ArtistPreview> GetList()
        {
            var repo = UowFactory.Get().Repository<ArtistRepository>();
            return ModelHelper.FetchList<ArtistPreview, Artist>(repo.GetAll());
        }
    }
}