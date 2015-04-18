﻿using Microsoft.Practices.ServiceLocation;

namespace Core.DataAccess.Repositories
{
    public sealed class UnitOfWorkFactory
    {
        public static IUnitOfWork Get()
        {
            return ServiceLocator.Current.GetInstance<IUnitOfWork>();
        }

        public static IUnitOfWork Get(string key)
        {
            return ServiceLocator.Current.GetInstance<IUnitOfWork>(key);
        }
    }
}