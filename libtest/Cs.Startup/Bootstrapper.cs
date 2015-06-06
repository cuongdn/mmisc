using System.Reflection;
using System.Web.Mvc;
using Core.Common.Utils;
using Core.DataAccess.Uow;
using Core.Web.Localization;
using Core.Web.Localization.Types;
using Cs.DbModel;
using Cs.Localization.FriendlyNames;
using FluentValidation.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
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

            //container.RegisterPerWebRequest<SchoolContext>();
            //container.RegisterPerWebRequest<IUnitOfWork, UnitOfWork>();

            var factory = new UowHandlerFactory(container);
            //factory.Register("default", () => new UnitOfWork(new SchoolContext()), new WebRequestLifestyle());
            //factory.Register("backup", () => new UnitOfWork(new BackupContext()), new WebRequestLifestyle());
            factory.Register<SchoolContext>(lifestyle: new WebRequestLifestyle());
            factory.Register<FakeContext>("FakeContext", new WebRequestLifestyle());
            container.RegisterPerWebRequest<IUowHandlerFactory>(() => factory);
            container.Verify();

            IoC.SetContainerProvider(() => container);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
