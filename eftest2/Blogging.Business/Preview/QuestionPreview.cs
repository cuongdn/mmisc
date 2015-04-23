using System;
using System.Collections.Generic;
using Blogging.DbModel.Entities;
using Blogging.DbModel.Repositories;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;

namespace Blogging.Business.Preview
{
    public class QuestionPreview : ModelBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        #region Factory Methods

        // ReSharper disable UnusedMember.Local
        private void Model_Fetch(Question dbEntity)
        // ReSharper restore UnusedMember.Local
        {
            ObjFacUtil.Fetch(this, dbEntity);
        }

        public static IList<QuestionPreview> GetList()
        {
            var repo = new QuestionRepository(UnitOfWorkFactory.Get());
            return ModelHelper.FetchList<QuestionPreview>(repo.GetAll());
        }

        #endregion
    }
}
