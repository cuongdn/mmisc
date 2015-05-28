using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Sample.DataAccess.Entities
{
    public class Log : AuditableEntity<long>
    {
        public DateTime? Date { get; set; } // Date
        public string Thread { get; set; } // Thread
        public string Level { get; set; } // Level
        public string Logger { get; set; } // Logger
        public string Message { get; set; } // Message
        public string Exception { get; set; } // Exception
        
    }
}
