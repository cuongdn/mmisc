using System.Linq;
using Core.Business.ObjectFactories;
using Core.Business.Utils;
using Cs.DbModel.Entities;
using Cs.DbModel.Repositories;

namespace Cs.Business.Edit
{
    public class InstructorEditObjectFactory : EditObjectFactory<InstructorEdit, Instructor>
    {
        protected override void FetchOthers()
        {
            ModelObject.OfficeLocation = DbEntity.OfficeAssignment.Location;
            FetchAssignedCourses();
        }

        private void FetchAssignedCourses()
        {
            ModelObject.AssignedCourses = AssignedCourseEdit.GetList(DbEntity);
        }

        public override void Get(object id)
        {
            DbEntity = new InstructorRepository(TheUnitOfWork).GetById((int)id);
        }

        public override void UpdateChildren()
        {
            if (DbEntity.OfficeAssignment == null)
            {
                DbEntity.OfficeAssignment = new OfficeAssignment();
            }
            DbEntity.OfficeAssignment.Location = ModelObject.OfficeLocation;

            if (ModelObject.SelectedCourses == null || !ModelObject.SelectedCourses.Any())
            {
                foreach (var courseInstructor in DbEntity.CourseInstructors)
                {
                    courseInstructor.MarkAsDeleted();
                }
            }
            else
            {
                UpdateAssignedCourses();
                ModelHelper.UpdateChildren<AssignedCourseEdit>(ModelObject.AssignedCourses, DbEntity);
            }
        }

        private void UpdateAssignedCourses()
        {
            FetchAssignedCourses();
            var list = ModelObject.AssignedCourses.Where(x => ModelObject.SelectedCourses.Contains(x.Id));
            foreach (var assignedCourseEdit in list)
            {
                assignedCourseEdit.Selected = true;
            }
        }
    }
}