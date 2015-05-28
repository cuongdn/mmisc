using System;
using System.Collections.Generic;
using Core.DataAccess.Entities;

namespace Sample.DataAccess.Entities
{
    public class Enrollment : Entity<int>
    {
        public int CourseId { get; set; } // CourseId
        public int StudentId { get; set; } // StudentId
        public int? Grade { get; set; } // Grade
        
        public virtual Course Course { get; set; } // FK_Enrollment_Course
        public virtual Student Student { get; set; } // FK_Enrollment_Student
    }
}
