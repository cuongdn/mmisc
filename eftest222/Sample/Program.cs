using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.Context;
using Core.DataAccess.Repositories;
using Sample.DataAccess.Context;
using Sample.DataAccess.Entities;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var uow = new UnitOfWork(new MyDbContext()))
            {
                var repo = uow.Repository<Course>();
                foreach (var course in repo.GetAll())
                {
                    Console.WriteLine(course.Id + " " + course.Title);
                }
            }
        }
    }

    public static class CourseRepository
    {
        public static IList<Course> GetAll(this IRepository<Course> repo)
        {
            return repo.Queryable().OrderBy(x => x.Title).ToList();
        }
    }
}
