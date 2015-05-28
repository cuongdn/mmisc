using System.ComponentModel.DataAnnotations;
using Blogging.DbModel.Entities;
using Core.Business.Common;
using Core.Business.Utils;

namespace Blogging.Business.Edit
{
    public class AnswerEdit : ModelEditBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        // ReSharper disable UnusedMember.Local
        private void Model_Fetch(Answer dbEntity)
        {
            ObjFacUtil.Fetch(this, dbEntity);
        }

        private void Model_Update(Question parent)
        {
            ObjFacUtil.UpdateChild<AnswerEdit, Answer, int>(this, parent.Answers);
        }
        // ReSharper restore UnusedMember.Local
    }
}