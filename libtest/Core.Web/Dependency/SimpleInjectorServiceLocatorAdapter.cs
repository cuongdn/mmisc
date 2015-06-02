using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;

namespace Core.Web.Dependency
{
    public class SimpleInjectorServiceLocatorAdapter : ServiceLocatorImplBase
    {
        private readonly Container _container;

        public SimpleInjectorServiceLocatorAdapter(Container container)
        {
            _container = container;
        }

        /// <summary>
        ///     When implemented by inheriting classes, this method will do the actual work of resolving
        ///     the requested service instance.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <param name="key">Name of registered service you want. May be null.</param>
        /// <returns>
        ///     The requested service instance.
        /// </returns>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return _container.GetInstance(serviceType);
            }
            throw new NotSupportedException("Keyed registration is not supported by the Simple Injector.");
        }

        /// <summary>
        ///     When implemented by inheriting classes, this method will do the actual work of
        ///     resolving all the requested service instances.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>
        ///     Sequence of service instance objects.
        /// </returns>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            foreach (var obj in _container.GetAllInstances(serviceType))
            {
                yield return obj;
            }
        }
    }
}