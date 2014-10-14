using Common.Business;
using DataAccess;
using FluentValidation;
using FluentValidation.Mvc;
using RepositoryPattern.Ef;
using RepositoryPattern.Ef.Factories;
using RepositoryPattern.Infrastructure;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Extensions
{
    public static class IoC
    {
        private static Assembly GetAssemblyByName(string name)
        {
            return GetAssemblyByNames(new[] { name }).FirstOrDefault();
        }
        private static IEnumerable<Assembly> GetAssemblyByNames(string[] names)
        {
            if (names == null || names.Length == 0)
            {
                return new List<Assembly>();
            }
            return AppDomain.CurrentDomain.GetAssemblies().Where(assembly => names.Contains(assembly.GetName().Name)).ToList();
        }
        public static void RegisterFromAssemblies(this Container container, IEnumerable<Assembly> assemblies = null, bool includeFluentValidatorFactory = true)
        {
            container.RegisterRepositories();
            if (assemblies != null)
            {
                foreach (var assembly in assemblies)
                {
                    container.RegisterValidators(assembly);
                    container.RegisterServices(assembly);
                }
            }
            if (includeFluentValidatorFactory)
            {
                container.RegisterFluentValidatorFactory();
            }
        }
        public static void RegisterFromAssemblies(this Container container, string[] assemblyNames = null, bool includeFluentValidatorFactory = true)
        {
            RegisterFromAssemblies(container, GetAssemblyByNames(assemblyNames), includeFluentValidatorFactory);
        }
        public static void RegisterValidators(this Container container, string assemblyName)
        {
            container.RegisterValidators(GetAssemblyByName(assemblyName));
        }
        public static void RegisterValidators(this Container container, Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }
            container.RegisterManyForOpenGeneric(typeof(IValidator<>), assembly);
        }
        public static void RegisterFluentValidatorFactory(this Container container)
        {
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
        public static void RegisterRepositories(this Container container)
        {
            RegisterRepositories(container, new WebRequestLifestyle());
        }
        public static void RegisterRepositories(this Container container, Lifestyle lifestyle)
        {
            container.Register<IDataContextAsync, DatabaseContext>(lifestyle);
            container.Register<IUnitOfWorkAsync, UnitOfWork>(lifestyle);
            container.RegisterSingle<IRepositoryProvider>(new RepositoryProvider(new RepositoryFactories()));
            container.RegisterOpenGeneric(typeof(IRepositoryAsync<>), typeof(Repository<>));
        }
    }
}
