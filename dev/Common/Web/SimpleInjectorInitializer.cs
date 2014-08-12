using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace Common.Web
{
    public static class SimpleInjectorInitializer
    {
        public static Container Container { get; private set; }

        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize(Action<Container> action)
        {
            // Did you know the container can diagnose your configuration? Go to: https://bit.ly/YE8OJj.
            var container = new Container();
            action(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            Container = container;
        }
    }
}