using System.Collections.Generic;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Cs.DbModel.Entities;
using Cs.DbModel.Repositories;

namespace Cs.Business.Edit
{
    public class AssignedCourseEdit : ModelEditBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
        public bool Selected { get; set; }

        public override bool IsNew
        {
            get { return Selected && !Assigned; }
        }

        public override bool IsDelete
        {
            get { return Assigned && !Selected; }
        }

        private void Model_Update(Instructor instructor)
        {
            CreateObjectFactory(instructor).UpdatePreparation();
        }

        private AssignedCourseEditObjectFactory CreateObjectFactory(Instructor instructor)
        {
            return new AssignedCourseEditObjectFactory
            {
                ModelObject = this,
                DbEntity = instructor
            };
        }

        private void Model_Fetch(Course course, Instructor instructor)
        {
            CreateObjectFactory(instructor).Fetch(course);
        }

        public static IList<AssignedCourseEdit> GetList(Instructor instructor)
        {
            var repo = new CourseRepository(UnitOfWorkFactory.Get());
            return ModelHelper.FetchList<AssignedCourseEdit>(repo.GetAll(), instructor);
        }
    }
}