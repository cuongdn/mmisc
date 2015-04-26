using System.Linq;
using Core.Business.ObjectFactories;
using Cs.DbModel.Entities;
using Omu.ValueInjecter;

namespace Cs.Business.Edit
{
    class AssignedCourseEditObjectFactory : ObjectFactory<AssignedCourseEdit, Instructor>
    {
        public void Fetch(Course course)
        {
            ModelObject.InjectFrom(course);
            ModelObject.Assigned = DbEntity.CourseInstructors.Any(x => x.CourseId == ModelObject.Id);
        }

        public void UpdatePreparation()
        {
            if (ModelObject.IsNew)
            {
                DbEntity.AssignCourse(ModelObject.Id);
            }
            else
            {
                var dbEntity = DbEntity.FindCourse(ModelObject.Id);
                if (dbEntity == null) return;
                if (ModelObject.IsDelete)
                {
                    dbEntity.MarkAsDeleted();
                }
            }
        }
    }
}