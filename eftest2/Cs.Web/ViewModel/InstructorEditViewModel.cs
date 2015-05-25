using System.Collections.Generic;
using Core.Web.ViewModel;
using Cs.Business.Edit;

namespace Cs.Web.ViewModel
{
    public class InstructorEditViewModel : ViewModelEdit<InstructorEdit>
    {
        public IList<AssignedCourseEdit> AssignedCourses
        {
            get
            {
                return GetObject(() => AssignedCourseEdit.GetList(ModelObject));
            }
        }

        public InstructorEditViewModel()
        {
            ModelObject = InstructorEdit.New();
        }

        public InstructorEditViewModel(int id, bool forDelete = false)
        {
            ModelObject = InstructorEdit.Get(id, forDelete);
        }
    }
}
