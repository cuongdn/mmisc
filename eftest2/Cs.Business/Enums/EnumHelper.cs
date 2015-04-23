using System;

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
    }
}
