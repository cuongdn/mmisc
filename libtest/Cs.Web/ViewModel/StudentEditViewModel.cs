using Core.Web.ViewModel;
using Cs.Business.Edit;

namespace Cs.Web.ViewModel
{
    public class StudentEditViewModel : ViewModelEdit<StudentEdit>
    {
        public StudentEditViewModel()
        {
        }

        public StudentEditViewModel(int id)
        {
            ModelObject = StudentEdit.Get(id);
        }
    }
}
