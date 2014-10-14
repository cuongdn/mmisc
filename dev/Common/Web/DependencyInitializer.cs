using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace Common.Web
{
    public static class DependencyInitializer
    {
        public static void Initialize(Action<Container> action)
        {
            var container = new Container();
            action(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}