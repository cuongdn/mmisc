using Core.Business.ObjectFactories;
using Cs.DbModel.Entities;

namespace Cs.Business.Preview
{
    class StudentPreviewPreviewObjectFactory : PreviewObjectFactory<StudentPreview, Student>
    {
        public override void Fetch()
        {
            base.Fetch();
            ModelObject.Enrollments = EnrollmentPreview.GetList(DbEntity.Id);
            //ModelObject.Enrollments = EnrollmentPreview.GetList(DbEntity);
        }

        //public override void Get(object id)
        //{
        //    //var repo = new StudentRepository(UnitOfWorkFactory.Get());
        //    //DbEntity = repo.GetById((int)id);
        //    DbEntity = DbUltil.Get<Student>(id);
        //}
    }
}