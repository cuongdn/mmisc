using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.Entities;

namespace Cs.DbModel.Entities
{
    public class Student : Entity<int>
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public virtual IList<Enrollment> Enrollments { get; set; }
    }

    public class Course : Entity<int>
    {
        public int Credits { get; set; }
        public string Title { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual IList<Enrollment> Enrollments { get; set; }
        public virtual IList<CourseInstructor> CourseInstructors { get; set; }
    }

    public class Enrollment : Entity<int>
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int? Grade { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }

    public class Instructor : Entity<int>
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }

        public Instructor()
        {
            CourseInstructors = new List<CourseInstructor>();
        }

        public virtual OfficeAssignment OfficeAssignment { get; set; }
        public virtual IList<CourseInstructor> CourseInstructors { get; set; }

        public CourseInstructor FindCourse(int courseId)
        {
            return CourseInstructors.SingleOrDefault(x => x.CourseId == courseId);
        }

        public void DeleteCourse(int courseId)
        {
            var course = FindCourse(courseId);
            if (course != null)
            {
                course.MarkAsDeleted();
                CourseInstructors.Remove(course);
            }
        }

        public void AssignCourse(int courseId)
        {
            CourseInstructors.Add(new CourseInstructor
            {
                CourseId = courseId,
                Instructor = this
            });
        }

        public void AssignOffice(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                OfficeAssignment = null;
            }
            else
            {
                if (OfficeAssignment == null)
                {
                    OfficeAssignment = new OfficeAssignment
                    {
                        Instructor = this
                    };
                }
                OfficeAssignment.Location = location;
            }
        }
    }

    public class OfficeAssignment : Entity<int>
    {
        public virtual Instructor Instructor { get; set; }
        public string Location { get; set; }
    }

    public class Department : Entity<int>
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }

        public int? InstructorId { get; set; }
        public virtual Instructor Administrator { get; set; }
    }

    public class CourseInstructor : EntityBase
    {
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
    }
}
