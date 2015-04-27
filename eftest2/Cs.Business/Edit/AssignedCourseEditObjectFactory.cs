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
            ModelObject.Assigned = DbEntity != null && DbEntity.CourseInstructors.Any(x => x.CourseId == ModelObject.Id);
        }

        public void UpdatePreparation()
        {
            if (ModelObject.IsNew)
            {
                DbEntity.AssignCourse(ModelObject.Id);
            }
            else
            {
                if (ModelObject.IsDelete)
                {
                    DbEntity.DeleteCourse(ModelObject.Id);
                }
            }
        }
    }
}