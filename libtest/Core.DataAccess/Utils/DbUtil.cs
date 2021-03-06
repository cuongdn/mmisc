﻿
using Core.DataAccess.Uow;

namespace Core.DataAccess.Utils
{
    public static class DbUtil
    {
        public static T Repository<T>(IUnitOfWork unitOfWork)
        {
            var activator = ActivatorHelper.Instance.GetActivator<T>();
            return activator(unitOfWork);
        }
    }
}
