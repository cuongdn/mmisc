using System.Collections.Generic;
using System.Web.Http;
using Cs.Business.Preview;

namespace Cs.WebApi.Controllers
{
    public class StudentController : ApiController
    {
        public IList<StudentPreview> Get()
        {
            return StudentPreview.GetAll();
        }
    }
}
