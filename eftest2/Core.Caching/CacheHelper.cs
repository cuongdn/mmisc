using System.Reflection;

namespace Core.Caching
{
    public static class CacheHelper
    {
        public static string GetKey(MethodBase method)
        {
            return string.Format("{0}.{1}.{2}", method.DeclaringType.Namespace, method.DeclaringType.Name, method.Name);
        }

        public static string GetKey(MethodBase method, params object[] parameterValues)
        {
            var key = GetKey(method);
            foreach (var str2 in parameterValues)
            {
                key = key + "|" + str2;
            }
            return key;
        }

    }

}
