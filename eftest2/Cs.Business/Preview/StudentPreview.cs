using System;
using System.Collections.Generic;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Cs.DbModel.Entities;
using Cs.DbModel.Repositories;

namespace Cs.Business.Preview
{
    public class StudentPreview : ModelBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public IList<EnrollmentPreview> Enrollments { get; set; }

        public static StudentPreview Get(int id)
        {
            return ObjectUtil.GetPreview(id, () => new StudentPreviewPreviewObjectFactory());
        }

        public static IList<StudentPreview> GetList()
        {
            var repo = new StudentRepository(UnitOfWorkFactory.Get());
            return ModelHelper.FetchList<StudentPreview, Student>(repo.GetAll());
        }
    }
}
