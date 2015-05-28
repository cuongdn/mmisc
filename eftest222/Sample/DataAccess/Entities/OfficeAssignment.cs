using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Sample.DataAccess.Entities
{
    public class OfficeAssignment : Entity<int>
    {
        public string Location { get; set; } // Location
        
        public virtual Instructor Instructor { get; set; } // FK_OfficeAssignment_Instructor
    }
}
