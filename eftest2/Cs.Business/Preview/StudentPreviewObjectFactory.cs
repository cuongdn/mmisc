using Core.Business.ObjectFactories;
using Cs.DbModel.Entities;

namespace Cs.Business.Preview
{
    class StudentPreviewObjectFactory : GenericObjectFactory<StudentPreview, Student>
    {
        protected override void FetchOthers()
        {
            ModelObject.Enrollments = EnrollmentPreview.GetList(DbEntity.Id);
            //ModelObject.Enrollments = EnrollmentPreview.GetList(DbEntity);
        }

        //public override void Get(object id)
        //{
        //    //var repo = new StudentRepository(UowFactory.Get());
        //    //DbEntity = repo.GetById((int)id);
        //    DbEntity = DbUltil.Get<Student>(id);
        //}
    }
}