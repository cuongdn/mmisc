using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using Common.Business;
using DataAccess;
using FluentValidation;
using FluentValidation.Mvc;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.Web;

namespace Common.Extensions
{
    public static class Objects
    {
        private static Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == name);
        }
        public static void RegisterModelValidators(this Container container, string assemblyName)
        {
            container.RegisterModelValidators(GetAssemblyByName(assemblyName));
        }
        public static void RegisterModelValidators(this Container container, Assembly assembly, bool includeFactory = true)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }
            container.RegisterManyForOpenGeneric(typeof(IValidator<>), assembly);
            if (includeFactory)
            {
                FluentValidationModelValidatorProvider.Configure(x => x.ValidatorFactory = new FluentValidatorFactory(container));
            }
        }
        public static void AutoRegister(this Container container)
        {
            AutoRegister(container, new WebRequestLifestyle());
        }
        public static void AutoRegister(this Container container, Lifestyle lifestyle)
        {
            container.RegisterDataAccess(lifestyle);
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                container.RegisterServices(assembly);
                container.RegisterModelValidators(assembly, false);
            }
            FluentValidationModelValidatorProvider.Configure(x => x.ValidatorFactory = new FluentValidatorFactory(container));
        }
        public static void RegisterServices(this Container container, string assemblyName)
        {
            container.RegisterServices(GetAssemblyByName(assemblyName));
        }
        public static void RegisterServices(this Container container, Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }
            container.RegisterManyForOpenGeneric(typeof(IService<>), AccessibilityOption.PublicTypesOnly,
                (type, implTypes) =>
                {
                    foreach (var implType in implTypes)
                    {
                        var serviceType = implType.GetInterfaces().FirstOrDefault(x => !x.IsGenericType);
                        if (serviceType != null)
                        {
                            container.Register(serviceType, implType, Lifestyle.Transient);
                        }
                    }
                }, assembly);
        }
        public static void RegisterDataAccess(this Container container, Lifestyle lifestyle)
        {
            container.Register<IDataContextAsync, DatabaseContext>(lifestyle);
            container.Register<IUnitOfWorkAsync, UnitOfWork>(lifestyle);
            container.RegisterSingle<IRepositoryProvider>(new RepositoryProvider(new RepositoryFactories()));
            container.RegisterOpenGeneric(typeof(IRepositoryAsync<>), typeof(Repository<>));
        }
    }
}
