using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Core
{
    /// <summary>
    /// Tracking individually modified properties
    /// </summary>
    public abstract class TrackableDbContext : GenericDbContext
    {
        /// <summary>
        /// Allow context records entity original values or not
        /// At the present it is a global configuration 
        /// </summary>
        //public static bool RecordEntityOrginalValues { get; set; }
        //static TrackableDbContext()
        //{
        //    RecordEntityOrginalValues = true;
        //}

        public bool RecordEntityOrginalValues { get; private set; }
        protected TrackableDbContext(string nameOrConnectionString, bool recordEntityOrginalValues)
            : base(nameOrConnectionString)
        {
            RecordEntityOrginalValues = recordEntityOrginalValues;
            ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += ObjectContext_ObjectMaterialized;
        }
        /// <summary>
        /// Store original values of entities
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObjectContext_ObjectMaterialized(object sender,
            System.Data.Entity.Core.Objects.ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectState;
            if (entity != null)
            {
                entity.ObjectState = ObjectState.Unchanged;
                if (RecordEntityOrginalValues)
                    entity.OriginalValues = BuildOriginalValues(Entry(entity).OriginalValues);
            }
        }
        /// <summary>
        /// Convert object's properties values to dictionary format
        /// </summary>
        /// <param name="originalValues"></param>
        /// <returns></returns>
        protected virtual Dictionary<string, object> BuildOriginalValues(DbPropertyValues originalValues)
        {
            var result = new Dictionary<string, object>();
            foreach (var propertyName in originalValues.PropertyNames)
            {
                var value = originalValues[propertyName];
                // copy the value of property into dictionary                
                if (value is DbPropertyValues)
                {
                    // complex property, using recursive call to build a nested dictionary
                    result[propertyName] = BuildOriginalValues((DbPropertyValues)value);
                }
                else
                {
                    // normal scalar properties
                    result[propertyName] = value;
                }
            }
            return result;
        }
        /// <summary>
        /// Before commit changes
        /// </summary>
        protected override void PreCommit()
        {
            foreach (var entry in ChangeTracker.Entries<IObjectState>())
            {
                IObjectState stateInfo = entry.Entity;
                if (RecordEntityOrginalValues)
                {
                    // convert state and populate original values back to entities before commit
                    entry.State = StateConverter.ToTrackingEntityState(stateInfo.ObjectState);
                    if (entry.State == EntityState.Unchanged)
                        ApplyPropertyChanges(entry.OriginalValues, stateInfo.OriginalValues);
                }
                else
                {
                    entry.State = StateConverter.ToEntityState(stateInfo.ObjectState);
                }
            }
        }
        /// <summary>
        ///  Set original values for entity
        /// </summary>
        /// <param name="values">Original value of entity that need to be updated from dictionary</param>
        /// <param name="originalValues">Recorded values when the entity was retrieved from the database</param>
        protected virtual void ApplyPropertyChanges(DbPropertyValues values, Dictionary<string, object> originalValues)
        {
            foreach (var originalValue in originalValues)
            {
                if (originalValue.Value is Dictionary<string, object>)
                {
                    ApplyPropertyChanges(
                        (DbPropertyValues)values[originalValue.Key],
                        (Dictionary<string, object>)originalValue.Value);
                }
                else
                {
                    values[originalValue.Key] = originalValue.Value;
                }
            }
        }
    }
}
