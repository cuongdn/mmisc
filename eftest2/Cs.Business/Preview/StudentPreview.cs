using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Business.Common;
using Core.Business.Utils;
using Core.Common.Infrastructure.Grid;
using Core.Common.Infrastructure.Paging;
using Core.DataAccess.Extensions;
using Core.DataAccess.Uow;
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
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime EnrollmentDate { get; set; }
        public IList<EnrollmentPreview> Enrollments { get; set; }

        public static StudentPreview Get(int id)
        {
            return ObjectUtil.GetPreview(id, () => new StudentPreviewObjectFactory());
        }

        public static StudentRepository Repository
        {
            get { return UowFactory.Get().Repository<StudentRepository>(); }
        }

        public static IPagedList<StudentPreview> GetPaged(GridRequest request)
        {
            return ModelHelper.FetchList<StudentPreview, Student>(Repository.GetPaged(request));
        }
    }
}
