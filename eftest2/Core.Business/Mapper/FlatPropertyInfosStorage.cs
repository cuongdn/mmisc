using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Core.Business.Common;
using Omu.ValueInjecter;

namespace Core.Business.Mapper
{
    public static class FlatPropertyInfosStorage
    {
        private static readonly IDictionary<Type, IEnumerable<FlatPropertyDescriptor>> Storage =
            new Dictionary<Type, IEnumerable<FlatPropertyDescriptor>>();
        private static readonly object PropsLock = new object();

        public static IEnumerable<FlatPropertyDescriptor> GetFlatProps(this object o)
        {
            var type = o.GetType();
            if (!Storage.ContainsKey(type))
            {
                lock (PropsLock)
                {
                    if (!Storage.ContainsKey(type))
                    {
                        var list = new List<FlatPropertyDescriptor>();
                        foreach (PropertyDescriptor propDescriptor in o.GetProps())
                        {
                            var flatAttribute = propDescriptor.Attributes.OfType<FlatAttribute>().SingleOrDefault();
                            if (flatAttribute == null) continue;
                            list.Add(new FlatPropertyDescriptor(flatAttribute, propDescriptor));
                        }
                        Storage.Add(type, list.ToArray());
                    }
                }
            }
            return Storage[type];
        }
    }
}