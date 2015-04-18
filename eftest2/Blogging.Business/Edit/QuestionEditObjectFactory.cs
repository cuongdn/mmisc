using Blogging.DbModel.Entities;
using Blogging.DbModel.Repositories;
using Core.Business.ObjectFactories;
using Core.Business.Utils;

namespace Blogging.Business.Edit
{
    public class QuestionEditObjectFactory : GenericObjectFactory<QuestionEdit, Question>
    {
        public override void NewModelObject()
        {
            ModelObject.Title = "tao lao";
        }

        public override void Get(object id)
        {
            var repo = new QuestionRepository(TheUnitOfWork);
            DbEntity = repo.GetById((int)id);
        }

        public override void Fetch()
        {
            base.Fetch();
            ModelObject.Answers = ModelPortal.FetchChildren<AnswerEdit>(DbEntity.Answers);
        }

        public override void UpdateChildren()
        {
            ModelPortal.UpdateChildren<AnswerEdit>(ModelObject.Answers, DbEntity);
        }
    }
}