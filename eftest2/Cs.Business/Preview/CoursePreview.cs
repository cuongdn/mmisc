using System.Collections.Generic;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Cs.DbModel.Entities;
using Cs.DbModel.Repositories;

namespace Cs.Business.Preview
{
    public class CoursePreview : ModelBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        [Flat]
        public string DepartmentName { get; set; }

        public static IList<CoursePreview> GetList()
        {
            var repo = new CourseRepository(UowFactory.Get());
            return ModelHelper.FetchList<CoursePreview, Course>(repo.GetAll());
            //return ModelHelper.FetchList<CoursePreview, CourseDto>(await repo.GetAllAsync());
        }
    }


}