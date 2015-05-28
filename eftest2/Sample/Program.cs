using System;
using Core.DataAccess.Repositories;
using Sample.DataAccess.Context;
using Sample.DataAccess.Repositories;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uow = new UnitOfWork(new EfDbContext()))
            {
                var repo = uow.Repository<CourseRepository>();
                foreach (var course in repo.Queryable())
                {
                    Console.WriteLine(course.Id);
                }
            }
        }
    }
}
