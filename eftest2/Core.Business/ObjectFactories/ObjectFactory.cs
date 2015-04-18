using Omu.ValueInjecter;

namespace Core.Business.ObjectFactories
{
    public class ObjectFactory<T, TE>
        where T : class, new()
        where TE : class, new()
    {
        public T ModelObject { get; set; }
        public TE DbEntity { get; set; }

        public virtual void Fetch()
        {
            if (ModelObject == null)
            {
                ModelObject = new T();
            }
            ModelObject.InjectFrom(DbEntity);
        }
    }
}