using System.Collections.Generic;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Context;
using Core.DataAccess.Repositories;
using Cs.DbModel.Entities;
using Cs.DbModel.Repositories;
using Omu.ValueInjecter;

namespace Cs.Business.Edit
{
    public class AssignedCourseEdit : ModelBase
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

        public static IList<AssignedCourseEdit> GetList(InstructorEdit instructor)
        {
            var repo = UowFactory.Get().Repository<CourseRepository>();
            return ModelHelper.FetchList<AssignedCourseEdit>(repo.GetAll(), instructor);
        }
    }
}