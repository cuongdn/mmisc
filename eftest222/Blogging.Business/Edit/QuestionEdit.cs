using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Blogging.DbModel.Entities;
using Core.Business.Common;
using Core.Business.Utils;

namespace Blogging.Business.Edit
{
    public class QuestionEdit : ModelEditBase
    {
        #region Model Properties

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public IList<AnswerEdit> Answers { get; set; }

        public override object IdValue
        {
            get { return Id; }
        }
        #endregion

        #region Factory Methods

        public static QuestionEdit New()
        {
            return ModelHelper.NewModelObject<QuestionEdit>();
        }

        public static QuestionEdit Get(int id, bool graphModel = true)
        {
            if (graphModel)
            {
                return ObjFacUtil.Get(id, () => new QuestionEditObjectFactory());
            }
            return ObjFacUtil.Get<QuestionEdit, Question>(id);
        }

        #endregion

        #region Data Access

        public override void CreateNew()
        {
            ObjFacUtil.NewModelObject(this, () => new QuestionEditObjectFactory());
        }

        public override bool Upsert(bool forceUpdate = false)
        {
            return ObjFacUtil.Upsert(this, forceUpdate, () => new QuestionEditObjectFactory(), false);
        }

        public override bool DeleteSelf()
        {
            return ObjFacUtil.Delete<QuestionEdit, Question>(Id);
        }

        #endregion
    }
}