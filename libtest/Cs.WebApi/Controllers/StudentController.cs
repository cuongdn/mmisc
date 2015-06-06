using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Cs.Business.Preview;

namespace Cs.WebApi.Controllers
{
    [EnableCors("http://localhost:8080", "*", "*")]
    public class StudentController : ApiController
    {
        public IList<StudentPreview> Get()
        {
            return StudentPreview.GetAll();
        }
    }
}
