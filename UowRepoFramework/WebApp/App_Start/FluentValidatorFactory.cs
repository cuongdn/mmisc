using System;
using FluentValidation;

namespace WebApp
{
    public class FluentValidatorFactory : ValidatorFactoryBase
    {
        private readonly IServiceProvider _service;
        public FluentValidatorFactory(IServiceProvider service)
        {
            _service = service;
        }
        public override IValidator CreateInstance(Type validatorType)
        {
            return _service.GetService(validatorType) as IValidator;
        }
        
    }
}