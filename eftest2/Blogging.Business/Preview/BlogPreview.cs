
using System.Collections.Generic;
using Blogging.DbModel.Dto;
using Blogging.DbModel.Repositories;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;

namespace Blogging.Business.Preview
{
    public class BlogPreview : ModelBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }

        // ReSharper disable UnusedMember.Local
        private void Model_Fetch(BlogDto dbEntity)
        // ReSharper restore UnusedMember.Local
        {
            ObjFacUtil.Fetch(this, dbEntity);
        }

        public static IList<BlogPreview> GetList()
        {
            var repo = new BlogRepository(UnitOfWorkFactory.Get());
            return ModelPortal.FetchChildren<BlogPreview>(repo.GetAll());
        }
    }
}
