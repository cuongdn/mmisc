using System.Data.Entity;

namespace Core.DataAccess.Infrastructure
{
    public class StateConverter
    {
        public static ObjectState ToObjectState(EntityState state)
        {
            switch (state)
            {
                case EntityState.Added:
                    return ObjectState.Added;

                case EntityState.Deleted:
                    return ObjectState.Deleted;

                case EntityState.Modified:
                    return ObjectState.Modified;

                default:
                    return ObjectState.NotSet;
            }
        }

        public static EntityState ToEntityState(ObjectState objectState, EntityState entityState)
        {
            switch (objectState)
            {
                case ObjectState.Added:
                    return EntityState.Added;

                case ObjectState.Modified:
                    return EntityState.Modified;

                case ObjectState.Deleted:
                    return EntityState.Deleted;

                case ObjectState.Unchanged:
                    return EntityState.Unchanged;

                default:
                    return entityState;
            }
        }
    }
}
