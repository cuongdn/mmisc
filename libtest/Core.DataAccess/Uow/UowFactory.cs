using Core.Common.Utils;

namespace Core.DataAccess.Uow
{
    public sealed class UowFactory
    {
        public static IUnitOfWork Get()
        {
            return Get(UowHandlerFactory.DefaultKey);
        }

        public static IUnitOfWork Get(string key)
        {
            var factory = IoC.Current.GetInstance<IUowHandlerFactory>();
            return factory.Create(key);
        }
    }
}