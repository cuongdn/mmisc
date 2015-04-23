using Core.Business.Common;

namespace Core.Web.ViewModel
{
    public class ViewModelEdit<T> : ViewModelPreview<T>
        where T : ModelEditBase
    {
        public virtual bool Upsert(bool forceUpdate = false)
        {
            return Found && ModelObject.Upsert(forceUpdate);
        }

        public virtual bool Delete()
        {
            return Found && ModelObject.Delete();
        }
    }
}
