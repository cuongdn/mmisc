namespace Core.Business.Common
{
    public abstract class ModelEditBase : ModelBase
    {
        public virtual bool IsDelete { get; set; }

        public virtual bool IsNew
        {
            get
            {
                return IdValue == null || IdValue.Equals(0);
            }
        }

        public virtual void CreateNew()
        {

        }

        public virtual bool Upsert(bool forceUpdate = false)
        {
            return true;
        }

        public virtual bool DeleteSelf()
        {
            return true;
        }
    }
}