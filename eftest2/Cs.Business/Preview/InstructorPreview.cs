using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Cs.DbModel.Entities;
using Cs.DbModel.Repositories;

namespace Cs.Business.Preview
{
    public class InstructorPreview : ModelBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime HireDate { get; set; }

        [Flat("OfficeAssignmentLocation")]
        public string OfficeLocation { get; set; }

        public static async Task<IList<InstructorPreview>> GetAllAsync()
        {
            var repo = UowFactory.Get().Repository<InstructorRepository>();
            return ModelHelper.FetchList<InstructorPreview, Instructor>(await repo.GetAllAsync());
        }
    }
}
