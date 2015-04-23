﻿using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.Repositories;
using Cs.DbModel.Entities;

namespace Cs.DbModel.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IList<Student> GetAll()
        {
            return DbSet.OrderBy(x => x.LastName)
                        .ThenBy(x => x.FirstMidName)
                        .ThenByDescending(x => x.EnrollmentDate)
                        .ToList();
        }

        public Student GetById(int id)
        {
            return DbSet.Include("Enrollments.Course")
                        .SingleOrDefault(x => x.Id == id);
        }
    }
}
