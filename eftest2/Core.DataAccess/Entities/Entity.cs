

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.DataAccess.Infrastructure;

namespace Core.DataAccess.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public abstract class EntityBase : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
        public void MarkAsDeleted()
        {
            ObjectState = ObjectState.Deleted;
        }
    }

    public abstract class EntityVersionable : EntityBase
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    public abstract class Entity<T> : EntityBase, IEntity<T>
    {
        public virtual T Id { get; set; }
    }

    public abstract class EntityVersionable<T> : EntityVersionable, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
