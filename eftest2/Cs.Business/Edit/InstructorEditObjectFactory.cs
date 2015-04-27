using System;
using System.Linq;
using Core.Business.ObjectFactories;
using Core.Business.Utils;
using Cs.DbModel.Entities;
using Cs.DbModel.Repositories;

namespace Cs.Business.Edit
{
    public class InstructorEditObjectFactory : EditObjectFactory<InstructorEdit, Instructor>
    {
        public override void NewModelObject()
        {
            FetchAssignedCourses();
            ModelObject.HireDate = DateTime.Today;
        }

        protected override void FetchOthers()
        {
            if (DbEntity.OfficeAssignment != null)
            {
                ModelObject.OfficeLocation = DbEntity.OfficeAssignment.Location;
            }
            FetchAssignedCourses();
        }

        public void FetchAssignedCourses()
        {
            ModelObject.AssignedCourses = AssignedCourseEdit.GetList(DbEntity);
        }

        public void UpdateSelectedStates()
        {
            if (ModelObject.SelectedCourses == null) return;
            var list = ModelObject.AssignedCourses.Where(x => ModelObject.SelectedCourses.Contains(x.Id));
            foreach (var assignedCourse in list)
            {
                assignedCourse.Selected = true;
            }
        }

        public override void Get(object id)
        {
            DbEntity = new InstructorRepository(TheUnitOfWork).GetById((int)id);
        }

        public override void UpdateChildren()
        {
            DbEntity.AssignOffice(ModelObject.OfficeLocation);

            if (ModelObject.SelectedCourses == null)
            {
                foreach (var courseInstructor in DbEntity.CourseInstructors)
                {
                    courseInstructor.MarkAsDeleted();
                }
            }
            else
            {
                FetchAssignedCourses();
                UpdateSelectedStates();
                ModelHelper.UpdateChildren<AssignedCourseEdit>(ModelObject.AssignedCourses, DbEntity);
            }
        }
    }
}