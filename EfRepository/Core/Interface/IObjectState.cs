using System.Collections.Generic;

namespace Core
{
    /// <summary>
    /// State of entity. Use own ObjectState instead of EntityState 
    /// so that it will have no dependencies on EF and will be implemented by domain classes
    /// </summary>
    public interface IObjectState
    {
        ObjectState ObjectState { get; set; }
        Dictionary<string, object> OriginalValues { get; set; }
    }
}