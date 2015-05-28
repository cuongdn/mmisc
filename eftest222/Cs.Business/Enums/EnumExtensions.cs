using System;
using System.ComponentModel;

namespace Cs.Business.Enums
{
    public static class EnumExtensions
    {
        public static T? ToEnum<T>(this object obj)
            where T : struct
        {
            T result;
            if (obj != null && Enum.TryParse(obj.ToString(), out result))
            {
                return result;
            }
            return null;
        }

        public static T ToEnum<T>(this object obj, T defaultValue)
            where T : struct
        {
            var result = obj.ToEnum<T>();
            return result == null ? defaultValue : result.Value;
        }

        public static string Description(this Enum obj)
        {
            var type = obj.GetType();
            var memInfo = type.GetMember(obj.ToString());
            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return obj.ToString();
        }

        //public static T GetEnumByStringValueAttribute<T>(this Enum obj, string description)
        //    where T : struct
        //{
        //    var type = obj.GetType();
        //    var memInfo = type.GetMember(obj.ToString());
        //    if (memInfo.Length > 0)
        //    {
        //        var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        //        var value = attrs.FirstOrDefault(x => x.Equals(description));
        //        if (value != null)
        //        {
        //            return ((DescriptionAttribute)attrs[0]).Description;
        //        }
        //    }
        //    return obj.ToString();
        //    throw new ArgumentException("The value '" + value + "' is not supported.");
        //}
    }
}
