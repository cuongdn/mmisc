using RepositoryPattern.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPattern.Ef
{
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}