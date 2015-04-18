using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace Core.Common.IoC
{
    public class StructureMapDependencyScope : ServiceLocatorImplBase
    {
        protected readonly IContainer Container;

        public StructureMapDependencyScope(IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            Container = container;
        }

        public override object GetService(Type serviceType)
        {
            if (serviceType == null)
                return null;
            try
            {
                return serviceType.IsAbstract || serviceType.IsInterface
                         ? Container.TryGetInstance(serviceType)
                         : Container.GetInstance(serviceType);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///		When implemented by inheriting classes, this method will do the actual work of resolving
        ///		the requested service instance.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <param name="key">Name of registered service you want. May be null.</param>
        /// <returns>
        /// The requested service instance.
        /// </returns>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return GetService(serviceType);
            }
            return Container.TryGetInstance(serviceType, key);
        }

        /// <summary>
        ///		When implemented by inheriting classes, this method will do the actual work of
        ///		resolving all the requested service instances.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>
        /// Sequence of service instance objects.
        /// </returns>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return Container.GetAllInstances(serviceType).Cast<object>();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.GetAllInstances(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}
