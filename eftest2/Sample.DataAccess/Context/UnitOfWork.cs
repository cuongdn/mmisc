using System;
using System.Data.Entity;
using Core.DataAccess.Repositories;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Context
{
    public class UnitOfWork : DataContext, IUnitOfWork
    {
        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Book> Books { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Department> Departments { get; set; }
        public IDbSet<Enrollment> Enrollments { get; set; }
        public IDbSet<Instructor> Instructors { get; set; }
        public IDbSet<Log> Logs { get; set; }
        public IDbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public IDbSet<Student> Students { get; set; }

        static UnitOfWork()
        {
            Database.SetInitializer<UnitOfWork>(null);
        }

        public UnitOfWork()
            : base("Name=UnitOfWork")
        {
        }
    }
}
