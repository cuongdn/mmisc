using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using Sample.DataAccess.Entities;

namespace Sample.DataAccess.Context
{
    public interface IUnitOfWork : IDisposable
    {
        IDbSet<Author> Authors { get; set; }
        IDbSet<Book> Books { get; set; }
        IDbSet<Course> Courses { get; set; }
        IDbSet<Department> Departments { get; set; }
        IDbSet<Enrollment> Enrollments { get; set; }
        IDbSet<Instructor> Instructors { get; set; }
        IDbSet<Log> Logs { get; set; }
        IDbSet<OfficeAssignment> OfficeAssignments { get; set; }
        IDbSet<Student> Students { get; set; }
        
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
