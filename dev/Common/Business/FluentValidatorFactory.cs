using FluentValidation;
using System;

namespace Common.Business
{
    public class FluentValidatorFactory : ValidatorFactoryBase
    {
        private readonly IServiceProvider _injector;
        public FluentValidatorFactory(IServiceProvider injector)
        {
            _injector = injector;
        }
        public override IValidator CreateInstance(Type validatorType)
        {
            return _injector.GetService(validatorType) as IValidator;
        }
    }
}