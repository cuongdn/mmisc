using DataAccess.Model;
using RepositoryPattern.UnitOfWork;
using Service;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        public IUnitOfWorkAsync UnitOfWork { get; set; }
        public ICategoryService CategoryService { get; set; }

        public CategoryController(IUnitOfWorkAsync unitOfWork, ICategoryService categoryService)
        {
            UnitOfWork = unitOfWork;
            CategoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View(CategoryService.Query().Select());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var data = CategoryService.Find(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(data);
                }
                CategoryService.Insert(data);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var data = CategoryService.Find(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category data)
        {
            try
            {
                CategoryService.Update(data);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CategoryService.Delete(id);
                UnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
