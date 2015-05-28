using System.Collections.Generic;
using System.Runtime;
using Core.Web.ViewModel;
using Cs.Business.Edit;
using Cs.Web.Lookup;

namespace Cs.Web.ViewModel
{
    public class InstructorEditViewModel : ViewModelEdit<InstructorEdit>
    {
        public IList<AssignedCoursePreview> AssignedCourses
        {
            get
            {
                return GetObject(() => AssignedCoursePreview.GetList(ModelObject));
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
