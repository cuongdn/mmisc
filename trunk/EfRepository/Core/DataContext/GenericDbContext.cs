using System;
using System.Data.Entity;
using System.Linq;

namespace Core
{
    /// <summary>
    /// DbContext works well for timestamp-style concurrency tokens
    /// </summary>
    public abstract class GenericDbContext : DbContext, IDataContext
    {
        protected GenericDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            // No need event that initializes for retrieved entities from database
            // becase they have ObjectState.Unchanged by default
        }
        public override int SaveChanges()
        {
            CheckForEntitiesWithoutStateInterface();
            PreCommit();
            var changes = base.SaveChanges();
            PostCommit();
            return changes;
        }
        /// <summary>
        /// Check if there are any entities that do not implement IObjectState
        /// </summary>
        protected virtual void CheckForEntitiesWithoutStateInterface()
        {
            var entitiesWithoutState =
                    from e in ChangeTracker.Entries()
                    where !(e.Entity is IObjectState)
                    select e;
            if (entitiesWithoutState.Any())
            {
                throw new NotSupportedException(
                    "All entities must implement IObjectWithState");
            }
        }
        /// <summary>
        /// Sync state of object before commit changes by converting ObjectState to EntityState
        /// </summary>
        protected virtual void PreCommit()
        {
            foreach (var entry in ChangeTracker.Entries<IObjectState>())
                entry.State = StateConverter.ToEntityState(entry.Entity.ObjectState);
        }
        /// <summary>
        /// Sync state of object after commit changes. Not implemented
        /// </summary>
        protected virtual void PostCommit()
        {
            //foreach (var entry in ChangeTracker.Entries<IObjectState>())
            //    entry.Entity.ObjectState = StateConverter.ToObjectState(entry.State);
        }
    }
}