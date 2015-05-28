using System.Reflection;
using System.Web.Mvc;
using Blogging.Localization.FriendlyNames;
using Core.Web.Dependency;
using Core.Web.Localization;
using FluentValidation.Mvc;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace Blogging.Startup
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

            var container = new Container(new ScanningRegistry());
            StructureMapDependencyResolver.Initialize(container);
            ServiceLocator.SetLocatorProvider(() => StructureMapDependencyResolver.Current);
            DependencyResolver.SetResolver(ServiceLocator.Current);

            LocalizationConfig.RegisterResources(Assembly.GetAssembly(typeof(BlogFriendlyNames)));

            FluentValidationModelValidatorProvider.Configure(x =>
            {
                x.ValidatorFactory = new StructureMapValidatorFactory();
            });
        }
    }
}
