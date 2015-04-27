using System.Collections.Generic;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Cs.DbModel.Entities;
using Cs.DbModel.Repositories;
using Omu.ValueInjecter;

namespace Cs.Business.Edit
{
    public class AssignedCoursePreview : ModelBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public InstructorEdit Instructor { get; set; }

        public bool Selected
        {
            get
            {
                return Instructor.SelectedCourses != null && Instructor.SelectedCourses.Contains(Id) ||
                       Instructor.AssignedCourses != null && Instructor.AssignedCourses.Contains(Id);
            }
        }

        private void Model_Fetch(Course course, InstructorEdit instructor)
        {
            this.InjectFrom(course);
            Instructor = instructor;
        }

        public static IList<AssignedCoursePreview> GetList(InstructorEdit instructor)
        {
            var repo = new CourseRepository(UnitOfWorkFactory.Get());
            return ModelHelper.FetchList<AssignedCoursePreview>(repo.GetAll(), instructor);
        }
    }
}