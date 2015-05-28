
using Core.DataAccess.Context;
using Core.DataAccess.Repositories;

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
