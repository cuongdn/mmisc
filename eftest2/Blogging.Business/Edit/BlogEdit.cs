using System.ComponentModel.DataAnnotations;
using Blogging.DbModel.Entities;
using Core.Business.Common;
using Core.Business.Utils;

namespace Blogging.Business.Edit
{
    public class BlogEdit : ModelEditBase
    {
        public override object IdValue
        {
            get { return Id; }
        }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public static BlogEdit Get(int id)
        {
            return ObjFacUtil.Get<BlogEdit, Blog>(id);
        }

        public override bool Upsert(bool forceUpdate = false)
        {
            return ObjFacUtil.Upsert<BlogEdit, Blog>(this, forceUpdate, refetch: false);
        }

        public override bool DeleteSelf()
        {
            return ObjFacUtil.Delete<QuestionEdit, Question>(Id);
        }

        public static BlogEdit New()
        {
            return ModelPortal.NewModelObject<BlogEdit>();
        }
    }
}
