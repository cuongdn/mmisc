using Omu.ValueInjecter;

namespace Core.Business.ObjectFactories
{
    public class GenericObjectFactory<T, TE> : ObjectFactoryBase<T, TE>
        where T : class, new()
        where TE : class, new()
    {
        public override void Fetch()
        {
            if (DbEntity == null) return;

            if (ModelObject == null)
            {
                ModelObject = new T();
            }
            ModelObject.InjectFrom<FlatLoopValueInjection>(DbEntity);
        }

        public override void Get(object id)
        {
        }
    }
}