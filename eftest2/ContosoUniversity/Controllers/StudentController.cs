using System.Net;
using System.Web.Mvc;
using Core.Web.Infrastructure;
using Cs.Business.Preview;
using Cs.Web;

namespace ContosoUniversity.Controllers
{
    public class StudentController : BaseController
    {
        // GET: Student
        public ActionResult Index()
        {
            return View(StudentPreview.GetList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View(StudentPreview.Get(id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View(new StudentViewModel());
        }

        // POST: Student/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel viewModel)
        {
            return SaveOr404(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var viewModel = new StudentViewModel(id.Value);
            return ViewOr404(viewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, StudentViewModel viewModel)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            return SaveOr404(viewModel, true);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
