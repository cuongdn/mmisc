using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Sample.DataAccess.Entities
{
    public class OfficeAssignment : Entity<int>
    {
        public override int Id
        {
            get { return InstructorId; }
            set { InstructorId = value; }
        }
        
        public int InstructorId { get; set; } // InstructorId (Primary key)
        public string Location { get; set; } // Location
        
        public virtual Instructor Instructor { get; set; } // FK_OfficeAssignment_Instructor
    }
}
