using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DataAccess.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}