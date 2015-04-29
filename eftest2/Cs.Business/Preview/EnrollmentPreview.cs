using System.Collections.Generic;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Cs.Business.Enums;
using Cs.DbModel.Entities;
using Cs.DbModel.Repositories;

namespace Cs.Business.Preview
{
    public class EnrollmentPreview : ModelBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public int? Grade { get; set; }

        public EGrade? GradeLetter
        {
            get { return Grade.ToEnum<EGrade>(); }
        }

        private void Model_Fetch(Enrollment dbEntity)
        {
            ObjectUtil.Fetch(this, dbEntity);
        }

        public static IList<EnrollmentPreview> GetList(Student dbEntity)
        {
            return ModelHelper.FetchList<EnrollmentPreview>(dbEntity.Enrollments);
        }

        public static IList<EnrollmentPreview> GetList(int studentId)
        {
            var repo = new EnrollmentRepository(UowFactory.Get());
            return ModelHelper.FetchList<EnrollmentPreview>(repo.GetByStudentId(studentId));
        }
    }
}
