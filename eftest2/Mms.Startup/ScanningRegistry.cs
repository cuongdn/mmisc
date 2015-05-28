using System.Data.Entity;
using System.Reflection;
using Core.DataAccess.Repositories;
using Core.Web.Localization;
using Core.Web.Localization.Types;
using FluentValidation;
using Mms.Business.Validators;
using Mms.DataAccess.Context;
using Mms.Localization.FriendlyNames;
using StructureMap.Configuration.DSL;

namespace Mms.Startup
{
    public class ScanningRegistry : Registry
    {
        public ScanningRegistry()
        {
            var provider = LocalizationConfig.RegisterResources(Assembly.GetAssembly(typeof(CommonFriendlyNames)));
            For<ILocalizedStringProvider>().Use(provider);
            For<IUnitOfWork>().Use<UnitOfWork>();
            For<DbContext>().Use<EfDbContext>();
            AssemblyScanner.FindValidatorsInAssemblyContaining<GenreEditValidator>()
                .ForEach(result => For(result.InterfaceType).Singleton().Use(result.ValidatorType));
        }
    }
}