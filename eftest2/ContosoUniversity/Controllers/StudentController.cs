using System.Web.Mvc;
using ContosoUniversity.Infrastructure;
using Core.Web.Infrastructure;
using Cs.Business.Preview;
using Cs.Web.ViewModel;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace ContosoUniversity.Controllers
{
    public class StudentController : BaseController
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Student_List([DataSourceRequest]DataSourceRequest request)
        {
            var result = StudentPreview.GetPaged(request.ToGridRequest())
                                       .ToDataSourceResult();
            return Json(result);
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

        public ActionResult Edit(int id)
        {
            var viewModel = new StudentEditViewModel(id);
            return ViewOr404(viewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentEditViewModel viewModel)
        {
            return SaveOr404(viewModel, true);
        }

        // GET: Student/Delete/5
        public ActionResult Student_Destroy([DataSourceRequest]DataSourceRequest request, int id)
        {
            var viewModel = new StudentEditViewModel(id);
            if (viewModel.Found)
            {
                DeleteObject(viewModel.ModelObject, true);
            }
            return Json(new[] { viewModel.ModelObject }.ToDataSourceResult(request, ModelState));
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError = null)
        {
            this.GridRouteValues();
            var viewModel = new StudentEditViewModel(id);
            return ViewDeleteOr404(viewModel, saveChangesError);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_Post(int id)
        {
            var viewModel = new StudentEditViewModel(id);
            return DeleteOr404(id, viewModel);
        }
    }
}
