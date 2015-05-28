using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Sample.DataAccess.Entities
{
    public class Student : Entity<int>
    {
        public override int Id
        {
            get { return StudentId; }
            set { StudentId = value; }
        }
        
        public int StudentId { get; set; } // StudentId (Primary key)
        public string LastName { get; set; } // LastName
        public string FirstMidName { get; set; } // FirstMidName
        public DateTime EnrollmentDate { get; set; } // EnrollmentDate
        
        public virtual ICollection<Enrollment> Enrollments { get; set; } // Enrollment.FK_Enrollment_Student
        
        public Student()
        {
            Enrollments = new List<Enrollment>();
        }
    }
}
