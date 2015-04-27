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

        private void Model_Fetch(Course course, Instructor instructor)
        {
            CreateObjectFactory(instructor).Fetch(course);
        }

        private void Model_Fetch(Course course)
        {
            CreateObjectFactory().Fetch(course);
        }

        private AssignedCourseEditObjectFactory CreateObjectFactory(Instructor instructor = null)
        {
            return new AssignedCourseEditObjectFactory
            {
                ModelObject = this,
                DbEntity = instructor
            };
        }

        public static IList<AssignedCourseEdit> GetList(Instructor instructor = null)
        {
            var repo = new CourseRepository(UnitOfWorkFactory.Get());
            return instructor == null
                ? ModelHelper.FetchList<AssignedCourseEdit>(repo.GetAll())
                : ModelHelper.FetchList<AssignedCourseEdit>(repo.GetAll(), instructor);
        }
    }
}