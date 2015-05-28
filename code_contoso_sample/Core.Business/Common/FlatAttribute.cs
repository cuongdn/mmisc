using System;

namespace Core.Business.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class FlatAttribute : Attribute
    {
        public string Name { get; private set; }

        public FlatAttribute()
        {
        }

        public FlatAttribute(string name)
        {
            Name = name;
        }
    }
}