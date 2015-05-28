using System.Web.Mvc;
using Blogging.Business.Preview;
using Blogging.Web.ViewModel;
using Core.Web.Infrastructure;

namespace Web.Controllers
{
    public class QuestionController : BaseController
    {
        // GET: Question
        public ActionResult Index()
        {
            return View(QuestionPreview.GetList());
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View(new QuestionEditViewModel());
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(QuestionEditViewModel viewModel)
        {
            if (viewModel.Upsert())
            {
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new QuestionEditViewModel(id);
            return ViewOr404(model, () => View(model));
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, QuestionEditViewModel viewModel)
        {
            return ViewOr404(viewModel, () =>
            {
                if (viewModel.Upsert(true))
                {
                    return RedirectToAction("Index");
                }
                return View(viewModel);
            });
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = new QuestionEditViewModel(id, false);
            return ViewOr404(viewModel, () =>
            {
                viewModel.Delete();
                return RedirectToAction("Index");
            });
        }

        //// POST: Question/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
