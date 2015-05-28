using System;
using Core.Business.Mapper;
using Omu.ValueInjecter;

namespace Core.Business.ObjectFactories
{
    public class ObjectFactory<T, TE> : ObjectFactoryBase<T, TE>
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
            ModelObject.InjectFrom<FlatWiseValueInjection>(DbEntity);
            FetchOthers();
        }

        protected virtual void FetchOthers()
        {

        }

        public override void Get(object id)
        {
        }
    }
}