using System;
using System.Linq;
using Core.Business.ObjectFactories;
using Cs.DbModel.Entities;
using Cs.DbModel.Repositories;

namespace Cs.Business.Edit
{
    public class InstructorEditObjectFactory : EditObjectFactory<InstructorEdit, Instructor>
    {
        public InstructorEditObjectFactory()
        {
        }

        public InstructorEditObjectFactory(InstructorEdit modelObject)
        {
            ModelObject = modelObject;
        }

        public override void NewModelObject()
        {
            ModelObject.HireDate = DateTime.Today;
        }

        protected override void FetchOthers()
        {
            if (DbEntity.OfficeAssignment != null)
            {
                ModelObject.OfficeLocation = DbEntity.OfficeAssignment.Location;
            }
            ModelObject.AssignedCourses = DbEntity.CourseInstructors.Select(x => x.CourseId).ToList();
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
                var assignedCourses = DbEntity.CourseInstructors.Select(x => x.CourseId).ToList();
                if (!assignedCourses.Any())
                {
                    DbEntity.AssignCourses(ModelObject.SelectedCourses);
                    return;
                }

                var deletedCourses = assignedCourses.Except(ModelObject.SelectedCourses);
                var newCourses = ModelObject.SelectedCourses.Except(assignedCourses);

                DbEntity.DeleteCourses(deletedCourses);
                DbEntity.AssignCourses(newCourses);
            }
        }
    }
}