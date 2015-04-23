using System.Data.Entity;
using Core.DataAccess.Repositories;
using Core.Web.Localization;
using Core.Web.Localization.Types;
using Cs.Business.Validators;
using Cs.DbModel;
using FluentValidation;
using StructureMap.Configuration.DSL;

namespace Cs.Startup
{
    public class ScanningRegistry : Registry
    {
        public ScanningRegistry()
        {
            For<ILocalizedStringProvider>().Use<MetadataLanguageProvider>();
            For<IUnitOfWork>().Use<UnitOfWork>();
            For<DbContext>().Use<SchoolContext>();
            For(typeof(IRepository<>)).Use(typeof(Repository<>));
            AssemblyScanner.FindValidatorsInAssemblyContaining<StudentEditValidator>()
                .ForEach(result => For(result.InterfaceType).Singleton().Use(result.ValidatorType));
        }
    }
}