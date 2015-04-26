using Core.Web.ViewModel;
using Cs.Business.Edit;

namespace Cs.Web.ViewModel
{
    public class InstructorEditViewModel : ViewModelEdit<InstructorEdit>
    {
        public InstructorEditViewModel()
        {
        }

        public InstructorEditViewModel(int id)
        {
            ModelObject = InstructorEdit.Get(id);
        }
    }
}
