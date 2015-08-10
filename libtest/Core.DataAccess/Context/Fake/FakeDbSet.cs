using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.DataAccess.Context.Fake.Supports;
using Core.DataAccess.Entities;
using Core.DataAccess.Infrastructure;

namespace Core.DataAccess.Context.Fake
{
    public class FakeDbSet<TEntity> : DbSet<TEntity>, IDbSet<TEntity>, IDbAsyncEnumerable<TEntity> where TEntity : EntityBase, new()
    {
        private readonly ObservableCollection<TEntity> _items;
        private readonly IQueryable _query;
        public string[] KeyNames { get; internal set; }

        public FakeDbSet()
        {
            _items = new ObservableCollection<TEntity>();
            _query = _items.AsQueryable();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return new AsyncEnumeratorWrapper<TEntity>(GetEnumerator());
        }

        IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
        {
            return new AsyncEnumeratorWrapper<TEntity>(GetEnumerator());
        }

        public IEnumerator<TEntity> GetEnumerator() { return _items.GetEnumerator(); }

        public Expression Expression { get { return _query.Expression; } }

        public Type ElementType { get { return _query.ElementType; } }

        public IQueryProvider Provider { get { return new AsyncQueryProviderWrapper<TEntity>(_query.Provider); } }

        public override TEntity Add(TEntity entity)
        {
            _items.Add(entity);
            return entity;
        }

        public override TEntity Remove(TEntity entity)
        {
            _items.Remove(entity);
            return entity;
        }

        public override TEntity Attach(TEntity entity)
        {
            switch (entity.ObjectState)
            {
                case ObjectState.Modified:
                    _items.Remove(entity);
                    _items.Add(entity);
                    break;

                case ObjectState.Deleted:
                    _items.Remove(entity);
                    break;

                case ObjectState.NotSet:
                case ObjectState.Unchanged:
                case ObjectState.Added:
                    _items.Add(entity);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            return entity;
        }

        public override TEntity Create() { return new TEntity(); }

        public override TDerivedEntity Create<TDerivedEntity>() { return Activator.CreateInstance<TDerivedEntity>(); }

        public override ObservableCollection<TEntity> Local { get { return _items; } }

        public override Task<TEntity> FindAsync(params object[] keyValues)
        {
            return new Task<TEntity>(() => Find(keyValues));
        }

        public override TEntity Find(params object[] keyValues)
        {
            return this.SingleOrDefault(GenerateKeyExpression(keyValues));
        }

        protected Expression<Func<TEntity, bool>> GenerateKeyExpression(params  object[] keyValues)
        {
            var expressions = new string[KeyNames.Length];
            for (var i = 0; i < KeyNames.Length; i++)
            {
                var name = KeyNames[i];
                expressions[i] = string.Format("{0}=@{1}", name, i);
            }
            return System.Linq.Dynamic.DynamicExpression.ParseLambda<TEntity, bool>(String.Join(" and ", expressions), keyValues);
        }

    }
}
