using Core.Web.ViewModel;
using Cs.Business.Edit;

namespace Cs.Web
{
    public class StudentViewModel : ViewModelBase<StudentEdit>
    {
        public StudentViewModel()
        {

        }

        public StudentViewModel(int id)
        {
            ModelObject = StudentEdit.Get(id);
        }
    }
}
