using Core.DataAccess.Entities;
using Core.DataAccess.Repositories;

namespace Core.DataAccess.Utils
{
    public static class DbUltil
    {
        public static T Get<T>(params object[] keyValues) where T : EntityBase
        {
            return UnitOfWorkFactory.Get().Repository<T>().Get(keyValues);
        }

        public static T Get<T>(string instanceKey, params object[] keyValues) where T : EntityBase
        {
            return UnitOfWorkFactory.Get(instanceKey).Repository<T>().Get(keyValues);
        }
    }
}
