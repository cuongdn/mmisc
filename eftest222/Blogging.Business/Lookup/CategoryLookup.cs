
using System;
using System.Collections.Generic;
using Blogging.DbModel.Dto;
using Blogging.DbModel.Entities;
using Blogging.DbModel.Repositories;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;

namespace Blogging.Business.Lookup
{
    [Serializable]
    public class CategoryLookup : ModelBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        // ReSharper disable UnusedMember.Local
        private void Model_Fetch(Category dbEntity)
        // ReSharper restore UnusedMember.Local
        {
            ObjFacUtil.Fetch(this, dbEntity);
        }

        // ReSharper disable UnusedMember.Local
        private void Model_Fetch(CategoryDto dbEntity)
        // ReSharper restore UnusedMember.Local
        {
            ObjFacUtil.Fetch(this, dbEntity);
        }

        public static IList<CategoryLookup> GetList()
        {
            var repo = new CategoryRepository(UnitOfWorkFactory.Get());
            return ModelHelper.FetchList<CategoryLookup>(repo.GetAll());
        }

        public static IList<CategoryLookup> GetListDto()
        {
            var repo = new CategoryRepository(UnitOfWorkFactory.Get());
            return ModelHelper.FetchList<CategoryLookup>(repo.GetCategories());
        }
    }
}
