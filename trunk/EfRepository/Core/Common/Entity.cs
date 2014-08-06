using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    /// <summary>
    /// Entity with state and original values that uses for tracking individually modified properties
    /// </summary>
    public abstract class Entity : IObjectState
    {
        /// <summary>
        /// State of Entity
        /// </summary>
        [NotMapped]
        public ObjectState ObjectState { get; set; }
        /// <summary>
        /// Record the properties that were modified is to keep track of the original values for existing entites
        /// </summary>
        [NotMapped]
        public Dictionary<string, object> OriginalValues { get; set; }
    }
}
