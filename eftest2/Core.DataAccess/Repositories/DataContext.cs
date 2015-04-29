using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using Core.DataAccess.Entities;
using Core.DataAccess.Infrastructure;

namespace Core.DataAccess.Repositories
{
    public abstract class DataContext : DbContext
    {
        protected DataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public static void SetNullDatabaseInitializer<T>()
               where T : DbContext
        {
            Database.SetInitializer(new NullDatabaseInitializer<T>());
        }

        public override int SaveChanges()
        {
            PreCommit();
            var result = base.SaveChanges();
            PostCommit();
            return result;
        }

        private void PostCommit()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                ((IObjectState)entry.Entity).ObjectState = StateConverter.ToObjectState(entry.State);
            }
        }

        protected virtual void PreCommit()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                SyncEntityState(entry);
                AuditEntity(entry);
            }
        }

        private void AuditEntity(DbEntityEntry entry)
        {
            var entity = entry.Entity as IAuditableEntity;
            if (entity == null || entry.State == EntityState.Deleted) return;

            switch (entry.State)
            {
                case EntityState.Added:
                    entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entity.UpdatedDate = DateTime.Now;
                    Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    break;
            }
        }

        private static void SyncEntityState(DbEntityEntry entry)
        {
            var state = ((IObjectState)entry.Entity).ObjectState;
            entry.State = StateConverter.ToEntityState(state, entry.State);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = GetType().Assembly.GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace)
                               && type.BaseType != null && type.BaseType.IsGenericType
                               && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}