using System;
using FluentValidation;
using Microsoft.Practices.ServiceLocation;

namespace Core.Web.Dependency
{
    public class StructureMapValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            return ServiceLocator.Current.GetInstance(validatorType) as IValidator;
        }
    }
}
