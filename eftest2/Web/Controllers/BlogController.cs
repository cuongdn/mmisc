using System.Web.Mvc;
using Blogging.Business.Preview;
using Blogging.Web.ViewModel;
using Core.Web.Infrastructure;

namespace Web.Controllers
{
    public class BlogController : BaseController
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View(BlogPreview.GetList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = new BlogEditViewModel(id);
            return ViewOr404(viewModel, () => View(viewModel));
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BlogEditViewModel viewModel)
        {
            return ViewOr404(viewModel, () =>
            {
                if (SaveObject(viewModel.ModelObject, true))
                {
                    return RedirectToAction("Index");
                }
                return View(viewModel);
            });
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blog/Delete/5
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
