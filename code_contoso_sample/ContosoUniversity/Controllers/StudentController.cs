using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Web.Infrastructure;
using Cs.Business.Preview;
using Cs.Web.ViewModel;

namespace ContosoUniversity.Controllers
{
    public class StudentController : BaseController
    {
        // GET: Student
        public async Task<ActionResult> Index(string sortBy, string sortOrder = "asc")
        {
            ViewBag.SortBy = sortBy;
            ViewBag.SortOrder = string.Equals(sortOrder, "asc") ? "desc" : "asc";
            ViewBag.OtherSortOrder = string.Equals(sortOrder, "asc") ? "asc" : "desc";

            return View(await StudentPreview.GetListAsync());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return ViewPreviewOr404(StudentPreview.Get(id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            //return ViewEditOr404(StudentEdit.New());
            return View(new StudentEditViewModel());
        }

        // POST: Student/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentEditViewModel viewModel)
        {
            return SaveOr404(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var viewModel = new StudentEditViewModel(id.Value);
            return ViewOr404(viewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentEditViewModel viewModel)
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
            var viewModel = new StudentEditViewModel(id.Value);
            return ViewDeleteOr404(viewModel, saveChangesError);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var viewModel = new StudentEditViewModel(id);
            return DeleteOr404(id, viewModel);
        }
    }
}
