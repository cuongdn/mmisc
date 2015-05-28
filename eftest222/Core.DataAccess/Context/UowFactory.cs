using Microsoft.Practices.ServiceLocation;

namespace Core.DataAccess.Context
{
    public sealed class UowFactory
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