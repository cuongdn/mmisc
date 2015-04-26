using System.Reflection;
using System.Web.Mvc;
using Core.Web.Dependency;
using Core.Web.Localization;
using Cs.Localization.FriendlyNames;
using FluentValidation.Mvc;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace Cs.Startup
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

            FluentValidationModelValidatorProvider.Configure(x =>
            {
                x.ValidatorFactory = new StructureMapValidatorFactory();
            });
        }
    }
}
