
using System;
using System.Reflection;
using System.Web.Mvc;

namespace Core.Web.Localization
{
    public static class LocalizationConfig
    {
        public static void RegisterResources(Assembly assembly, Func<Type, bool> predicate = null)
        {
            var stringProvider = new ResourceStringProvider(assembly, predicate);
            ModelMetadataProviders.Current = new LocalizedModelMetadataProvider(stringProvider);
            ModelValidatorProviders.Providers.Clear();
            ModelValidatorProviders.Providers.Add(new LocalizedModelValidatorProvider());
        }
    }
}
