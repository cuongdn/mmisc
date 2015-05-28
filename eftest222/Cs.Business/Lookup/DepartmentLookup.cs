
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Cs.DbModel.Dto;
using Cs.DbModel.Repositories;

namespace Cs.Business.Lookup
{
    public class DepartmentLookup : ModelBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public static async Task<IList<DepartmentLookup>> GetList()
        {
            var repo = new DepartmentRepository(UowFactory.Get());
            return ModelHelper.FetchList<DepartmentLookup, DepartmentDto>(await repo.GetLookupListAsync());
        }
    }
}
