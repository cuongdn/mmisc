using System.Data.Entity;
using Blogging.Business.Validator;
using Blogging.DbModel.DataContext;
using Core.DataAccess.Repositories;
using Core.Web.Localization;
using Core.Web.Localization.Types;
using FluentValidation;
using StructureMap.Configuration.DSL;

namespace Blogging.Startup
{
    public class ScanningRegistry : Registry
    {
        public ScanningRegistry()
        {
            For<ILocalizedStringProvider>().Use<MetadataLanguageProvider>();
            For<IUnitOfWork>().Use<UnitOfWork>();
            For<DbContext>().Use<BlogContext>();
            For(typeof(IRepository<>)).Use(typeof(Repository<>));
            AssemblyScanner.FindValidatorsInAssemblyContaining<BlogEditValidator>()
                .ForEach(result => For(result.InterfaceType).Singleton().Use(result.ValidatorType));
        }
    }
}