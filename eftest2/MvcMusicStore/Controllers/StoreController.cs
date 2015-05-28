using System.Web.Mvc;
using Mms.Business.Preview;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            return PartialView(GenrePreview.GetList());
        }
    }
}