using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Cs.Business.Enums;
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

        public static async Task<IList<StudentPreview>> GetListAsync()
        {
            var repo = new StudentRepository(UowFactory.Get());
            return ModelHelper.FetchList<StudentPreview, Student>(await repo.GetAllAsync());
        }

        public static IList<StudentPreview> GetList()
        {
            var repo = new StudentRepository(UowFactory.Get());
            return ModelHelper.FetchList<StudentPreview, Student>(repo.GetAll());
        }

        public static IList<StudentPreview> GetList(string sortBy, string sortOrder)
        {
            var repo = new StudentRepository(UowFactory.Get());

            var list = repo.Query()
                           .OrderBy(string.Format("{0} {1}", sortBy ?? "Id", sortOrder))
                           .List();

            return ModelHelper.FetchList<StudentPreview, Student>(list);
        }
    }
}
