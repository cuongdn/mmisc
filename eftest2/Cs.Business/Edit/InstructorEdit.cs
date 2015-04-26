using System;
using System.Collections.Generic;
using Core.Business.Common;
using Core.Business.Utils;
using Cs.DbModel.Entities;

namespace Cs.Business.Edit
{
    public class InstructorEdit : ModelEditBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }

        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string OfficeLocation { get; set; }
        public DateTime HireDate { get; set; }
        public IList<AssignedCourseEdit> AssignedCourses { get; set; }
        public IList<int> SelectedCourses { get; set; }

        public static InstructorEdit New()
        {
            return ModelHelper.NewModelObject<InstructorEdit>();
        }

        public static InstructorEdit Get(int id)
        {
            return ObjectUtil.GetEdit(id, () => new InstructorEditObjectFactory());
        }

        public override bool Upsert(bool forceUpdate = false)
        {
            return ObjectUtil.Upsert(this, forceUpdate, () => new InstructorEditObjectFactory());
        }

        public override bool Delete()
        {
            return ObjectUtil.Delete<InstructorEdit, Instructor>(Id);
        }
    }
}
