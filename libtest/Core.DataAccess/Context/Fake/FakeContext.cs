using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Core.Common.Utils;
using Core.DataAccess.Entities;

namespace Core.DataAccess.Context.Fake
{
    public abstract class FakeContext : IFakeContext
    {
        private readonly Dictionary<Type, object> _fakeDbSets;
        private readonly Dictionary<Type, string[]> _entityKeyMembers;

        protected FakeContext()
        {
            _fakeDbSets = new Dictionary<Type, object>();
            _entityKeyMembers = new Dictionary<Type, string[]>();
        }

        public IDictionary<Type, string[]> EntityKeyMembers
        {
            get { return _entityKeyMembers; }
        }

        public void Dispose()
        {
        }

        public int SaveChanges()
        {
            return 0;
        }

        public Task<int> SaveChangesAsync()
        {
            return new Task<int>(() => 0);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return new Task<int>(() => 0);
        }

        public DbSet<T> Set<T>() where T : class
        {
            return (DbSet<T>)_fakeDbSets[typeof(T)];
        }

        protected void AddFakeDbSet<TEntity, TFakeDbSet>(params string[] keyMembers)
            where TEntity : EntityBase, new()
            where TFakeDbSet : FakeDbSet<TEntity>, IDbSet<TEntity>, new()
        {
            ArgumentChecker.NotNullOrEmpty(keyMembers, "keyMembers");

            var fakeDbSet = Activator.CreateInstance<TFakeDbSet>();
            fakeDbSet.KeyNames = keyMembers;
            _fakeDbSets.Add(typeof(TEntity), fakeDbSet);
            _entityKeyMembers.Add(typeof(TEntity), fakeDbSet.KeyNames);
        }

        protected void AddFakeDbSet<TEntity>(params string[] keyMembers)
           where TEntity : EntityBase, new()
        {
            AddFakeDbSet<TEntity, FakeDbSet<TEntity>>(keyMembers);
        }

        protected void AddFakeDbSet<TEntity, TFakeDbSet>(params Expression<Func<TEntity, object>>[] keyMembers)
            where TEntity : EntityBase, new()
            where TFakeDbSet : FakeDbSet<TEntity>, IDbSet<TEntity>, new()
        {
            AddFakeDbSet<TEntity, TFakeDbSet>(ParseKeyMembers(keyMembers));
        }

        protected void AddFakeDbSet<TEntity>(params Expression<Func<TEntity, object>>[] keyMembers)
            where TEntity : EntityBase, new()
        {
            AddFakeDbSet<TEntity>(ParseKeyMembers(keyMembers));
        }

        private string[] ParseKeyMembers<TEntity>(IEnumerable<Expression<Func<TEntity, object>>> keyMembers)
        {
            return keyMembers.Select(x => x.Body as MemberExpression ?? ((UnaryExpression)x.Body).Operand as MemberExpression)
                             .Select(body => body.Member.Name).ToArray();
        }

    }
}
