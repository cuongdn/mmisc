using System.ComponentModel;
using Core.Business.Common;

namespace Core.Business.Mapper
{
    public class FlatPropertyDescriptor
    {
        public FlatAttribute FlatAttribute { get; set; }
        public PropertyDescriptor PropertyDescriptor { get; set; }

        public FlatPropertyDescriptor(FlatAttribute flatAttribute, PropertyDescriptor propertyDescriptor)
        {
            FlatAttribute = flatAttribute;
            PropertyDescriptor = propertyDescriptor;
        }
    }
}