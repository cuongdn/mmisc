using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using Core.DataAccess.Repositories;
using Cs.DbModel.Entities;
using Cs.DbModel.Repositories;

namespace Cs.Service.Controllers
{
    public class StudentsController : ODataController
    {
        private static IUnitOfWork TheUnitOfWork
        {
            get { return UowFactory.Get(); }
        }

        private readonly StudentRepository _repository;

        public StudentsController()
        {
            _repository = TheUnitOfWork.Repository<StudentRepository>();
        }

        private bool ProductExists(int key)
        {
            return _repository.Queryable().Any(p => p.Id == key);
        }

        [EnableQuery]
        public IQueryable<Student> Get()
        {
            return _repository.Queryable();
        }

        [EnableQuery]
        public SingleResult<Student> Get([FromODataUri] int key)
        {
            var result = _repository.Queryable().Where(x => x.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.Insert(student);
            await TheUnitOfWork.SaveChangesAsync();
            return Created(student);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Student> student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await _repository.GetAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            student.Patch(entity);
            try
            {
                await TheUnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                throw;
            }
            return Updated(entity);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Student update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }
            _repository.Update(update);
            try
            {
                await TheUnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                throw;
            }
            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var student = await _repository.GetAsync();
            if (student == null)
            {
                return NotFound();
            }
            _repository.Delete(student);
            await TheUnitOfWork.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
