using System.Reflection;
using System.Web.Mvc;
using DataAccess.Model;
using FluentValidation.Mvc;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using WebApp;
using Service;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace WebApp
{
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            // Did you know the container can diagnose your configuration? Go to: https://bit.ly/YE8OJj.
            var container = new Container();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            var webLifestyle = new WebRequestLifestyle();
            container.RegisterSingle<IRepositoryProvider>(new RepositoryProvider(new RepositoryFactories()));

            container.Register<IDataContextAsync, DatabaseContext>(webLifestyle);
            container.Register<IUnitOfWorkAsync, UnitOfWork>(webLifestyle);
            container.RegisterOpenGeneric(typeof(IRepositoryAsync<>), typeof(Repository<>));
            container.Register<ICategoryService, CategoryService>();

            FluentValidationModelValidatorProvider
                .Configure(x => x.ValidatorFactory = new FluentValidatorFactory(container));

            //FluentValidationModelValidatorProvider.Configure();
        }
    }
}