using Core.Business.Common;
using Core.Business.Utils;
using Cs.DbModel.Entities;

namespace Cs.Business.Edit
{
    public class CourseEdit : ModelEditBase
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
            return ObjectUtil.Delete<CourseEdit, Course>(Id);
        }
    }
}