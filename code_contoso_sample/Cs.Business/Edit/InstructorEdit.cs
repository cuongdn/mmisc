using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int DepartmentId { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string OfficeLocation { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        public IList<int> AssignedCourses { get; set; }
        public IList<int> SelectedCourses { get; set; }

        public override void CreateNew()
        {
            new InstructorEditObjectFactory(this).NewModelObject();
        }

        public static InstructorEdit New()
        {
            return ModelHelper.NewModelObject<InstructorEdit>();
        }

        public static InstructorEdit Get(int id, bool forDelete = false)
        {
            return forDelete ? ObjectUtil.GetEdit<InstructorEdit, Instructor>(id)
                : ObjectUtil.GetEdit(id, () => new InstructorEditObjectFactory());
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
