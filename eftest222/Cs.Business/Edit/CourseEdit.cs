using System.Collections.Generic;
using Core.Business.Common;
using Core.Business.Utils;
using Core.DataAccess.Repositories;
using Cs.DbModel.Entities;
using Cs.DbModel.Repositories;

namespace Cs.Business.Edit
{
    public class CourseEdit : ModelEditVersionable
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }

        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public static CourseEdit New()
        {
            return ModelHelper.NewModelObject<CourseEdit>();
        }

        public static CourseEdit Get(int id)
        {
            return ObjectUtil.GetEdit<CourseEdit, Course>(id);
        }

        public override bool Upsert(bool forceUpdate = false)
        {
            return ObjectUtil.Upsert<CourseEdit, Course>(this, forceUpdate);
        }

        public override bool Delete()
        {
            return ObjectUtil.Delete<CourseEdit, Course>(this);
        }
    }
}