using System.Web.Mvc;
using TwitterBootstrap3;

namespace Web.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            
            ViewData["BMVC.Globals.ShowRequiredStar"] = false;
            //ViewData["BMVC.Globals.ButtonStyle"] = ButtonStyle.Primary;
            return View();
        }
    }
}