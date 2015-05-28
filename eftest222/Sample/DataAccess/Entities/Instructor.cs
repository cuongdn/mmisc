using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Sample.DataAccess.Entities
{
    public class Instructor : Entity<int>
    {
        public string LastName { get; set; } // LastName
        public string FirstMidName { get; set; } // FirstMidName
        public DateTime HireDate { get; set; } // HireDate
        
        public virtual ICollection<Course> Courses { get; set; } // Many to many mapping
        public virtual ICollection<Department> Departments { get; set; } // Department.FK_Department_Instructor
        public virtual OfficeAssignment OfficeAssignment { get; set; } // OfficeAssignment.FK_OfficeAssignment_Instructor
        
        public Instructor()
        {
            Departments = new List<Department>();
            Courses = new List<Course>();
        }
    }
}
