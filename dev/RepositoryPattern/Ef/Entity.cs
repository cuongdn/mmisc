using System.ComponentModel.DataAnnotations.Schema;
using RepositoryPattern.Infrastructure;

namespace RepositoryPattern.Ef
{
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}