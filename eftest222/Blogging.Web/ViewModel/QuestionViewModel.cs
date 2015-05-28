using Blogging.Business.Edit;
using Core.Web.ViewModel;

namespace Blogging.Web.ViewModel
{
    public class QuestionEditViewModel : ViewModelBase<QuestionEdit>
    {
        public QuestionEditViewModel()
        {
            ModelObject = QuestionEdit.New();
        }

        public QuestionEditViewModel(int id, bool graphModel = true)
        {
            ModelObject = QuestionEdit.Get(id, graphModel);
        }
    }
}
