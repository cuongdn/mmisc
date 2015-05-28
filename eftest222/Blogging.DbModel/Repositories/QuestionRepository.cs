using System.Collections.Generic;
using System.Linq;
using Blogging.DbModel.Entities;
using Core.DataAccess.Repositories;

namespace Blogging.DbModel.Repositories
{
    public class QuestionRepository : Repository<Question>
    {
        public QuestionRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IList<Question> GetAll()
        {
            return DbSet.OrderBy(x => x.Title).ToList();
        }

        public Question GetById(int id)
        {
            return DbSet.Include("Answers").FirstOrDefault(x => x.Id == id);
        }
    }
}
