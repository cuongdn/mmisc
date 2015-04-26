using System.Data.Entity;
using System.Reflection;
using Core.DataAccess.Repositories;
using Core.Web.Localization;
using Core.Web.Localization.Types;
using Cs.Business.Validators;
using Cs.DbModel;
using Cs.Localization.FriendlyNames;
using FluentValidation;
using StructureMap.Configuration.DSL;

namespace Cs.Startup
{
    public class ScanningRegistry : Registry
    {
        public ScanningRegistry()
        {
            var provider = LocalizationConfig.RegisterResources(Assembly.GetAssembly(typeof(StudentFriendlyNames)));
            For<ILocalizedStringProvider>().Use(provider);
            For<IUnitOfWork>().Use<UnitOfWork>();
            For<DbContext>().Use<SchoolContext>();
            For(typeof(IRepository<>)).Use(typeof(Repository<>));
            AssemblyScanner.FindValidatorsInAssemblyContaining<StudentEditValidator>()
                .ForEach(result => For(result.InterfaceType).Singleton().Use(result.ValidatorType));
        }
    }
}