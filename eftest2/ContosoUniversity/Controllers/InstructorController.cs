using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Web.Infrastructure;
using Cs.Business.Preview;
using Cs.Web.ViewModel;

namespace ContosoUniversity.Controllers
{
    public class InstructorController : BaseController
    {
        // GET: Student
        public async Task<ActionResult> Index()
        {
            return View(await InstructorPreview.GetAllAsync());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return ViewPreviewOr404(StudentPreview.Get(id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View(new InstructorEditViewModel());
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstructorEditViewModel viewModel)
        {
            return SaveOr404(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var viewModel = new InstructorEditViewModel(id.Value);
            return ViewOr404(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InstructorEditViewModel viewModel)
        {
            return SaveOr404(viewModel, true);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = null)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var viewModel = new InstructorEditViewModel(id.Value, true);
            return ViewDeleteOr404(viewModel, saveChangesError);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(InstructorEditViewModel viewModel)
        {
            return DeleteOr404(viewModel.ModelObject.Id, viewModel);
        }
    }
}