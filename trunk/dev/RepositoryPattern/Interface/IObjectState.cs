using System.ComponentModel.DataAnnotations.Schema;
using RepositoryPattern.Infrastructure;

namespace RepositoryPattern.Interface
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}