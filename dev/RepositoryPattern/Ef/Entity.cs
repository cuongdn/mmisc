using System.ComponentModel.DataAnnotations.Schema;
using RepositoryPattern.Infrastructure;
using RepositoryPattern.Interface;

namespace RepositoryPattern.Ef
{
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}