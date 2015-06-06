using System;
using System.Collections.Generic;
using Core.Common.Utils;
using Core.DataAccess.Context;
using SimpleInjector;

namespace Core.DataAccess.Uow
{
    public class UowHandlerFactory : Dictionary<string, Func<IUnitOfWork>>, IUowHandlerFactory
    {
        internal const string DefaultKey = "Default";

        private readonly Dictionary<string, InstanceProducer> _producers =
            new Dictionary<string, InstanceProducer>(StringComparer.OrdinalIgnoreCase);

        private readonly Container _container;

        public UowHandlerFactory(Container container)
        {
            ArgumentChecker.NotNull(container, "container");
            _container = container;
        }

        public IUnitOfWork Create(string key)
        {
            var handler = _producers[key].GetInstance();
            return (IUnitOfWork)handler;
        }

        public void Register<T>(string key = DefaultKey, Lifestyle lifestyle = null) where T :
            IDataContext, new()
        {
            Register(key, () => new UnitOfWork(new T()), lifestyle);
        }

        public void Register(string key, Func<IUnitOfWork> instanceCreator, Lifestyle lifestyle = null)
        {
            lifestyle = lifestyle ?? Lifestyle.Transient;
            var producer = lifestyle.CreateProducer(instanceCreator, _container);
            _producers.Add(key, producer);
        }
    }
}