using System;
using System.Diagnostics;
using Common.Logging;
using ConsoleApplication1.Utils;
using Core.Logging;

namespace ConsoleApplication1
{
    class Program2
    {
        private object _i;

        public Program2(object i)
        {
            _i = i;
        }
    }

    class Program
    {
        private static readonly ILog Log = Logger.Get("abc");

        static void Main(string[] args)
        {
            var n = 3000000;
            var stop = Stopwatch.StartNew();

            for (int i = 0; i < n; i++)
            {
                var instance = new Program2(i);
            }

            Console.WriteLine(stop.ElapsedMilliseconds);

            stop = Stopwatch.StartNew();

            for (int i = 0; i < n; i++)
            {
                var instance = Activator.CreateInstance(typeof(Program2), i);
            }

            Console.WriteLine(stop.ElapsedMilliseconds);

            stop = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
            {
                var ctor = ActivatorHelper.GetActivator<Program2>();
                var instance = ctor(i);
            }

            Console.WriteLine(stop.ElapsedMilliseconds);

            stop = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
            {
                var ctor = LazyActivatorHelper.Instance.GetActivator<Program2>();
                var instance = ctor(i);
            }

            Console.WriteLine(stop.ElapsedMilliseconds);


            //var key = CacheHelper.GetKey(MethodBase.GetCurrentMethod(), 1, 2, bool.TrueString, false);
            //var ms = (DateTime.Now.Millisecond);
            //Console.WriteLine(ms);
            //CacheFactory.Current.Add(key, ms);

            //Console.WriteLine("aaa");

            //Console.WriteLine(CacheFactory.Current.Get<int>(key));


            //Console.WriteLine(typeof(Program).FullName);
            ////Log.ThreadVariablesContext.Set("url", "http://abc.com");
            //Log.Debug("b");
            //Log.Warn("Asdfasfasf");
            //Log.Error("Asdfasfasf");
            //Log.Info("Asdfasfasf");
            //Log.Fatal("Asdfasfasf");
        }
    }
}
