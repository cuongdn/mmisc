using System;
using Common.Logging;

namespace Core.Logging
{
    public static class Logger
    {
        private const string DefaultLogger = "Default";

        public static ILog Default
        {
            get { return Get(DefaultLogger); }
        }

        public static ILog Get(string name)
        {
            return LogManager.GetLogger(name);
        }

        public static ILog Get<T>()
        {
            return LogManager.GetLogger(typeof(T));
        }

        public static ILog Get(Type type)
        {
            return LogManager.GetLogger(type);
        }
    }
}