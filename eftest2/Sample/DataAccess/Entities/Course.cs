using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Sample.DataAccess.Entities
{
    public class Course : EntityVersionable<int>
    {
        public string Title { get; set; } // Title
        public int Credits { get; set; } // Credits
        public int DepartmentId { get; set; } // DepartmentId
        
        public virtual ICollection<Enrollment> Enrollments { get; set; } // Enrollment.FK_Enrollment_Course
        public virtual ICollection<Instructor> Instructors { get; set; } // Many to many mapping
        public virtual Department Department { get; set; } // FK_Course_Department
        
        public Course()
        {
            Enrollments = new List<Enrollment>();
            Instructors = new List<Instructor>();
        }
    }
}
