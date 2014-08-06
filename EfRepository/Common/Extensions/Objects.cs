using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Common
{
    public static class Objects
    {
        /// <summary>
        /// Returns an Object with the specified Type and whose value is equivalent to the specified object.
        /// </summary>
        /// <param name="value">An Object that implements the IConvertible interface.</param>
        /// <returns>
        /// An object whose Type is conversionType (or conversionType's underlying type if conversionType
        /// is Nullable&lt;&gt;) and whose value is equivalent to value. -or- a null reference, if value is a null
        /// reference and conversionType is not a value type.
        /// </returns>
        /// <remarks>
        /// This method exists as a workaround to System.Convert.ChangeType(Object, Type) which does not handle
        /// nullables as of version 2.0 (2.0.50727.42) of the .NET Framework. The idea is that this method will
        /// be deleted once Convert.ChangeType is updated in a future version of the .NET Framework to handle
        /// nullable types, so we want this to behave as closely to Convert.ChangeType as possible.
        /// This method was written by Peter Johnson at:
        /// http://aspalliance.com/author.aspx?uId=1026.
        /// </remarks>
        /// 
        public static T ChangeTypeTo<T>(this object value)
        {
            Type conversionType = typeof(T);
            return (T)ChangeTypeTo(value, conversionType);
        }

        public static T ChangeTypeTo<T>(this object value, object defaultValue)
        {
            try
            {
                Type conversionType = typeof(T);
                return (T)ChangeTypeTo(value, conversionType);
            }
            catch (Exception)
            {
                return (T)defaultValue;
            }
        }

        public static object ChangeTypeTo(this object value, Type conversionType)
        {
            // Note: This if block was taken from Convert.ChangeType as is, and is needed here since we're
            // checking properties on conversionType below.
            if (conversionType == null)
                throw new ArgumentNullException("conversionType");

            // If it's not a nullable type, just pass through the parameters to Convert.ChangeType

            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                // It's a nullable type, so instead of calling Convert.ChangeType directly which would throw a
                // InvalidCastException (per http://weblogs.asp.net/pjohnson/archive/2006/02/07/437631.aspx),
                // determine what the underlying type is
                // If it's null, it won't convert to the underlying type, but that's fine since nulls don't really
                // have a type--so just return null
                // Note: We only do this check if we're converting to a nullable type, since doing it outside
                // would diverge from Convert.ChangeType's behavior, which throws an InvalidCastException if
                // value is null and conversionType is a value type.
                if (value == null)
                    return null;

                // It's a nullable type, and not null, so that means it can be converted to its underlying type,
                // so overwrite the passed-in conversion type with this underlying type
                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            else if (conversionType == typeof(Guid))
            {
                return new Guid(value.ToString());

            }
            else if (conversionType == typeof(Int64) && value.GetType() == typeof(int))
            {
                //there is an issue with SQLite where the PK is ALWAYS int64. If this conversion type is Int64
                //we need to throw here - suggesting that they need to use LONG instead


                throw new InvalidOperationException("Can't convert an Int64 (long) to Int32(int). If you're using SQLite - this is probably due to your PK being an INTEGER, which is 64bit. You'll need to set your key to long.");
            }

            // Now that we've guaranteed conversionType is something Convert.ChangeType can handle (i.e. not a
            // nullable type), pass the call on to Convert.ChangeType
            return Convert.ChangeType(value, conversionType);
        }

        public static Dictionary<string, object> ToDictionary(this object value)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            PropertyInfo[] props = value.GetType().GetProperties();
            foreach (PropertyInfo pi in props)
            {
                try
                {
                    result.Add(pi.Name, pi.GetValue(value, null));
                }
                catch { }
            }
            return result;
        }

        public static T FromDictionary<T>(this Dictionary<string, object> settings, T item) where T : class
        {
            PropertyInfo[] props = item.GetType().GetProperties();
            //FieldInfo[] fields = item.GetType().GetFields();
            foreach (PropertyInfo pi in props)
            {
                if (settings.ContainsKey(pi.Name))
                {
                    if (pi.CanWrite)
                        pi.SetValue(item, settings[pi.Name], null);
                }
            }
            return item;
        }

        public static T CopyTo<T>(this object From, T to) where T : class
        {
            Type t = From.GetType();

            var settings = From.ToDictionary();

            to = settings.FromDictionary(to);

            return to;
        }

        public static Dictionary<string, string> ToDictionary(this System.Collections.Specialized.NameValueCollection value, string prefix)
        {
            var dic = new System.Collections.Generic.Dictionary<string, string>();
            int index = prefix.Length;
            foreach (var key in value.AllKeys)
            {
                if (key.StartsWith(prefix))
                {
                    dic.Add(key.Substring(index), value[key]);
                }
            }
            return dic;
        }
        public static List<string> ToParams(this System.Collections.Specialized.NameValueCollection value, string name = "id")
        {
            if (value[name] == null)
                return new List<string>();
            var list = (from id in value[name].Split(',')
                        let trimmed = id.Trim()
                        where !String.IsNullOrEmpty(trimmed)
                        select trimmed).ToList();
            return list;
        }
        public static bool IsNullOrWhiteSpace(this object value)
        {
            return value == null || value.ToString().Trim() == "";
        }

        public static void Merge(this IDictionary<string, object> dic, string key, object value)
        {
            if (!dic.ContainsKey(key))
                dic.Add(key, value);
            else
                dic[key] = value;
        }
        public static IDictionary<string, object> Merge(this IDictionary<string, object> source, params IDictionary<string, object>[] dictionaries)
        {
            foreach (var dic in dictionaries)
            {
                foreach (var key in dic.Keys)
                {
                    Merge(source, key, dic[key]);
                }
            }
            return source;
        }

        public static string Format(this object value, string format)
        {
            return String.Format(format, value);
        }
    }

}