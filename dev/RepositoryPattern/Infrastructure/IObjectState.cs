using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPattern.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}