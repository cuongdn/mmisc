﻿using System;
using FluentValidation;

namespace Common.Business
{
    public class FluentValidatorFactory : ValidatorFactoryBase
    {
        private IServiceProvider Injector { get; set; }
        public FluentValidatorFactory(IServiceProvider injector)
        {
            Injector = injector;
        }
        public override IValidator CreateInstance(Type validatorType)
        {
            return Injector.GetService(validatorType) as IValidator;
        }
    }
}