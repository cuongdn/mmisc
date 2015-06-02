using System.Reflection;
using System.Web.Mvc;
using Core.DataAccess.Context;
using Core.DataAccess.Uow;
using Core.Web.Dependency;
using Core.Web.Localization;
using Core.Web.Localization.Types;
using Cs.DbModel;
using Cs.Localization.FriendlyNames;
using FluentValidation.Mvc;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace Cs.Startup
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
            var container = new Container();
            var provider = LocalizationConfig.RegisterResources(Assembly.GetAssembly(typeof(StudentFriendlyNames)));
            container.RegisterSingle<ILocalizedStringProvider>(provider);
            container.RegisterPerWebRequest<IUnitOfWork, UnitOfWork>();
            container.RegisterPerWebRequest<IDataContext, SchoolContext>();
            container.Verify();

            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
