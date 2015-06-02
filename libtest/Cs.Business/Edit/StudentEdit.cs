using System;
using System.ComponentModel.DataAnnotations;
using Core.Business.Common;
using Core.Business.Utils;
using Cs.Business.Validators;
using Cs.DbModel.Entities;
using FluentValidation.Attributes;

namespace Cs.Business.Edit
{
    [Validator(typeof(StudentEditValidator))]
    public class StudentEdit : ModelEditBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public static StudentEdit New()
        {
            return ModelHelper.NewModelObject<StudentEdit>();
        }

        public static StudentEdit Get(int id)
        {
            return ObjectUtil.GetEdit<StudentEdit, Student>(id);
        }

        public override bool Upsert(bool forceUpdate = false)
        {
            return ObjectUtil.Upsert<StudentEdit, Student>(this, forceUpdate);
        }

        public override bool Delete()
        {
            return ObjectUtil.Delete<StudentEdit, Student>(Id);
        }
    }
}
