using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Enums
    {
        public static Dictionary<string, int> ToStringIntDic(Type enumType)
        {
            return Enum.GetValues(enumType).Cast<int>().
                            ToDictionary(x => Enum.GetName(enumType, x));
        }

        public static Dictionary<int, string> ToIntStringDic(Type enumType)
        {
            var dic = new Dictionary<int, string>();
            foreach (var value in Enum.GetValues(enumType))
                dic.Add((int)value, value.ToString());
            return dic;
        }
    }
}
