using System.Web.Mvc;
using Core.Web.Infrastructure;
using Cs.Business.Preview;
using Cs.Web.ViewModel;

namespace Cs.ContosoUniversity.Controllers
{
    public class CourseController : BaseController
    {
        // GET: Student
        public ActionResult Index()
        {
            return View(CoursePreview.GetList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return ViewPreviewOr404(StudentPreview.Get(id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View(new CourseEditViewModel());
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseEditViewModel viewModel)
        {
            return SaveOr404(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new CourseEditViewModel(id);
            return ViewOr404(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourseEditViewModel viewModel)
        {
            return SaveOr404(viewModel, true);
        }

        // GET: Student/AttachDelete/5
        public ActionResult Delete(int? id, bool? saveChangesError = null)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var viewModel = new CourseEditViewModel(id.Value);
            return ViewDeleteOr404(viewModel, saveChangesError);
        }

        // POST: Student/AttachDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CourseEditViewModel viewModel)
        {
            return DeleteOr404(id, viewModel);
        }
    }
}
