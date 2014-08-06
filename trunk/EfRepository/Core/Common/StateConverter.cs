using System;
using System.Data.Entity;

namespace Core
{
    /// <summary>
    /// Helper class uses to convert state of object
    /// </summary>
    public class StateConverter
    {

        /// <summary>
        /// Convert ObjectState back to EntityState
        /// </summary>
        public static EntityState ToEntityState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
        /// <summary>
        /// Convert ObjectState to EntityState but ignore state ObjectState.Modified 
        /// </summary>
        public static EntityState ToTrackingEntityState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
        /// <summary>
        /// Convert EntityState to ObjectState 
        /// </summary>
        public static ObjectState ToObjectState(EntityState state)
        {
            switch (state)
            {
                case EntityState.Unchanged:
                case EntityState.Detached:
                    return ObjectState.Unchanged;
                case EntityState.Added:
                    return ObjectState.Added;
                case EntityState.Modified:
                    return ObjectState.Modified;
                case EntityState.Deleted:
                    return ObjectState.Deleted;
                default:
                    throw new ArgumentOutOfRangeException("state");
            }
        }
    }
}
