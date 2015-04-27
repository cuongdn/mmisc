using System;
using System.Linq;
using Omu.ValueInjecter;

namespace Core.Business.Mapper
{
    public class FlatWiseValueInjection : LoopValueInjectionBase
    {
        protected override void Inject(object source, object target)
        {
            target.InjectFrom(source);

            foreach (var property in target.GetFlatProps())
            {
                var pd = property.PropertyDescriptor;
                var es = UberFlatter.Flat(property.FlatAttribute.Name ?? pd.Name, source,
                                x => TypesMatch(x, pd.PropertyType)).ToList();

                var endpoint = es.FirstOrDefault();
                if (endpoint == null) continue;

                var value = endpoint.Property.GetValue(endpoint.Component);
                if (AllowSetValue(value))
                {
                    pd.SetValue(target, SetValue(value));
                }
            }
        }

        protected virtual bool TypesMatch(Type sourceType, Type targetType)
        {
            return targetType == sourceType;
        }

        protected virtual object SetValue(object sourcePropertyValue)
        {
            return sourcePropertyValue;
        }
    }
}
