using System.Collections;
using System.Collections.Generic;
using Core.Web.ViewModel;
using Cs.Business.Edit;

namespace Cs.Web.ViewModel
{
    public class InstructorEditViewModel : ViewModelEdit<InstructorEdit>
    {
        public IList<AssignedCourseEdit> AssignedCourse
        {
            get { return GetObject(() => AssignedCourseEdit.GetList()); }
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
