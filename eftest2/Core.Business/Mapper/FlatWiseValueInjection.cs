using System;
using System.ComponentModel;
using System.Linq;
using Core.Business.Common;
using Omu.ValueInjecter;

namespace Core.Business.Mapper
{
    public class FlatWiseValueInjection : LoopValueInjectionBase
    {
        protected override void Inject(object source, object target)
        {
            target.InjectFrom(source);

            foreach (PropertyDescriptor propDescriptor in target.GetProps())
            {
                var pd = propDescriptor;
                var flatAttribute = propDescriptor.Attributes.OfType<FlatAttribute>().SingleOrDefault();
                if (flatAttribute == null) continue;

                var es = UberFlatter.Flat(flatAttribute.Name ?? pd.Name, source,
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
