using System.Web.Mvc;
using Core.DataAccess.Uow;

namespace Cs.ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Response.Write(UowFactory.Get() + "<br>");
            Response.Write(UowFactory.Get() + "<br>");
            Response.Write(UowFactory.Get() + "<br>");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}