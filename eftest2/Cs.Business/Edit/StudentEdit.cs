using System;
using Core.Business.Common;
using Core.Business.Utils;
using Cs.DbModel.Entities;

namespace Cs.Business.Edit
{
    public class StudentEdit : ModelEditBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

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
