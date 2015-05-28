using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Sample.DataAccess.Entities
{
    public class Department : Entity<int>
    {
        public string Name { get; set; } // Name
        public decimal Budget { get; set; } // Budget
        public DateTime StartDate { get; set; } // StartDate
        public int? InstructorId { get; set; } // InstructorId
        
        public virtual ICollection<Course> Courses { get; set; } // Course.FK_Course_Department
        public virtual Instructor Instructor { get; set; } // FK_Department_Instructor
        
        public Department()
        {
            Courses = new List<Course>();
        }
    }
}
